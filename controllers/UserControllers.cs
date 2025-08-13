using Microsoft.AspNetCore.Mvc;
using SmartEvent.API.Models;

namespace SmartEvent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();

        // CREATE
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            user.Id = Guid.NewGuid().ToString();  
            users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // READ - All
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(users);
        }

        // READ - By ID
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            users.Remove(user);
            return NoContent();
        }
    }
}