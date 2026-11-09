using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POE.Models;

namespace POE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        // GET: api/participants/{username}/results
        [HttpGet("{username}/results")]
        public IActionResult GetResults(string username)
        {
            // Replace with your service call to fetch completed results captured by the organiser
            var results = new List<ParticipantResultDto>
        {
            new() { EventName = "City Marathon", EventDate = DateTime.Now.AddDays(-14), CategoryName = "10km Run", FinishTime = "00:52:10", Position = 47, TotalFinishers = 312 }
        };
            return Ok(results);
        }

        // GET: api/participants/{username}
        [HttpGet("{username}")]
        public IActionResult GetProfile(string username)
        {
            var profile = new UserProfileDto { Username = username, FullName = "Lesego Leqola", Email = "lesego@example.com", PhoneNumber = "0821234567", ProfilePictureUrl = "/images/default-avatar.png" };
            return Ok(profile);
        }

        // PUT: api/participants/update
        [HttpPut("update")]
        public IActionResult UpdateProfile([FromBody] UserProfileDto model)
        {
            // Save profile updates to database/service here
            return Ok(new { message = "Profile updated successfully" });
        }
    }
}
