using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;

namespace SmartEvent.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("verify-token")]
        public async Task<IActionResult> VerifyToken([FromBody] string idToken)
        {
            try
            {
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                var uid = decodedToken.Uid;
                return Ok(new { uid });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}