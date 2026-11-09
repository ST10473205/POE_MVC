using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POE.Services;
using POE.Models;

namespace POE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRaceDayService _raceService;

        public AuthController(IRaceDayService raceService)
        {
            _raceService = raceService;
        }

        [HttpPost("login")]
        public ActionResult<object> Login([FromBody] loginDTO loginDto)
        {
            var user = _raceService.Authenticate(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "The password or username is invalid" });
            }
            // Return Http 200 ok when the login is successful and send the user's authentication details
            return Ok(new
            {
                Token = "mock-jwt-token-" + user.Id,
                Username = user.Username,
                Role = user.Role
            });
        }
    }
}
