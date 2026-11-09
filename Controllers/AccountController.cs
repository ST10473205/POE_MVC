using Microsoft.AspNetCore.Mvc;
using POE_MVC.Models;
using POE_MVC.Services;

namespace POE_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRaceApiClient _apiClient;

        public AccountController(IRaceApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if 
                (!ModelState.IsValid)
            { 
                 return View(model);
            }
            // Calls your API (localhost:7100) to verify credentials
            var authResponse = await _apiClient.LoginAsync(model);

            if (authResponse != null)
            {
                // Save the session locally on the MVC app (localhost:7066)
                HttpContext.Session.SetString("Username", model.Username);

                TempData["SuccessMessage"] = "Logged in successfully!";
                return RedirectToAction("Index", "Events");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }





        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}
