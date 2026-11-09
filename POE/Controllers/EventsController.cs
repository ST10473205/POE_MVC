using Microsoft.AspNetCore.Mvc;
using POE.Models;
using POE.Services;

namespace POE.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IRaceDayService _raceDayService;

        public EventsController(IRaceDayService raceDayService)
        {
            _raceDayService = raceDayService;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _raceDayService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var eventItem = _raceDayService.GetEventById(id);
            if (eventItem == null) return NotFound();
            return Ok(eventItem);
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventModel model)
        {
            var createdEvent = _raceDayService.AddEvent(model);
            return Ok(createdEvent);
        }

        // ---> ADD YOUR ENROL ENDPOINT HERE <---
        [HttpPost("enrol")]
        public IActionResult EnrolUser([FromBody] EnrolmentDto model)
        {
            if (model == null || string.IsNullOrEmpty(model.EmergencyContact))
            {
                return BadRequest("Invalid enrolment details.");
            }

            // You can process or store the enrolment data here (e.g., CategoryName & EmergencyContact)

            return Ok(new { message = "Enrolled successfully", data = model });
        }
    }
}