using Microsoft.AspNetCore.Mvc;
using POE_MVC.Models;
using POE_MVC.Services;

namespace POE_MVC.Controllers
{
    public class EventsController(IRaceApiClient raceApiClient) : Controller
    {
        // GET: /Events/Index
        public async Task<IActionResult> Index()
        {
            // Fetch events from the API and pass them to the view
            var events = await raceApiClient.GetEventsAsync();
            return View(events);
        }

        // GET: /Events/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await raceApiClient.GetEventByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        // GET: /Events/Enrol/{id}
        [HttpGet]
        public IActionResult Enrol(int id)
        {
            var model = new CreateEnrolmentViewModel { EventId = id };
            return View(model);
        }

        // POST: /Events/Enrol
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enrol(CreateEnrolmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Note: Ensure your API client has a method for this or update accordingly
                string username = HttpContext.Session.GetString("Username") ?? "Guest";
                bool success = await raceApiClient.RegisterUserForEventAsync(model, username);

                if (success)
                {
                    TempData["SuccessMessage"] = "Successfully enrolled in the event!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Server rejected the enrolment. Please check your details.";
                return View(model);
            }
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "Unable to connect to the server. Please try again later.";
                return View(model);
            }
        }

        // GET: /Events/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel model, IFormFile? bannerImage)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                if (bannerImage != null && bannerImage.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(bannerImage.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await bannerImage.CopyToAsync(fileStream);
                    }

                    model.ImageUrl = "/images/" + uniqueFileName;
                }

                bool added = await raceApiClient.AddEventAsync(model);
                if (added)
                {
                    TempData["SuccessMessage"] = "Event created successfully!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Failed to save event to the API backend.";
                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while uploading the image or creating the event.";
                return View(model);
            }
        }
    }
}