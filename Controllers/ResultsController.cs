using Microsoft.AspNetCore.Mvc;
using POE_MVC.Services;

namespace POE_MVC.Controllers
{
    public class ResultsController(IRaceApiClient raceApiClient) : Controller
    {
        public async Task<IActionResult> Index()
        {
            string username = HttpContext.Session.GetString("Username") ?? "Guest";
            if (username == "Guest") return RedirectToAction("Login", "Account");

            var results = await raceApiClient.GetParticipantResultsAsync(username);
            return View(results);
        }
    }
}