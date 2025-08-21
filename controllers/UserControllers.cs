using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEvent.API.Models;

namespace SmartEvent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE - Firebase Auth ile
        [HttpPost("firebase")]
        public async Task<IActionResult> CreateUserFromFirebase([FromBody] FirebaseAuthRequest request)
        {
            try
            {
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.IdToken);
                var uid = decodedToken.Uid;

                var userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);

                var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == uid);
                if (existingUser != null)
                {
                    return Ok(new { message = "Kullanıcı zaten kayıtlı", user = existingUser });
                }

                var newUser = new User
                {
                    Id = uid,
                    Name = userRecord.DisplayName ?? "Anonim",
                    Email = userRecord.Email ?? "unknown@email.com",
                    Role = "user"
                };

                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(401, $"Firebase doğrulama hatası: {ex.Message}");
            }
        }

        // READ - All
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

        // READ - By ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User updatedUser)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }

}