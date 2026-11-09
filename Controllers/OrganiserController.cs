using Microsoft.AspNetCore.Mvc;
using POE_MVC.Services;

namespace POE_MVC.Controllers
{
    public class OrganiserController : Controller
    {
        private readonly IRaceApiClient _raceApiClient;

        public OrganiserController(IRaceApiClient raceApiClient)
        {
            _raceApiClient = raceApiClient;
        }

        // GET: /Organiser/Dashboard
        public IActionResult Dashboard()
        {
            // Optional: Add dashboard stats or logic here
            return View();
        }

        // GET: /Organiser/ManageEvents
        public async Task<IActionResult> ManageEvents()
        {
            // Fetch events to manage
            var events = await _raceApiClient.GetEventsAsync();
            return View("~/Views/Organiser/ManageEvents.cshtml", events);
        }
    }
}