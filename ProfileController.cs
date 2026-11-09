using Microsoft.AspNetCore.Mvc;
using POE_MVC.Models;
using POE_MVC.Services;

namespace POE_MVC.Controllers
{
    public class ProfileController(IRaceApiClient raceApiClient) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string username = HttpContext.Session.GetString("Username") ?? "Guest";
            if (username == "Guest") return RedirectToAction("Login", "Account");

            var profile = await raceApiClient.GetUserProfileAsync(username);
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserProfileDto model, IFormFile? profilePicture)
        {
            if (profilePicture != null && profilePicture.Length > 0)
            {
                // Upload directory path under wwwroot
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "profiles");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(profilePicture.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await profilePicture.CopyToAsync(fileStream);
                }

                // Set web relative URL path for the image element
                model.ProfilePictureUrl = "/images/profiles/" + uniqueFileName;
            }
            bool success = await raceApiClient.UpdateUserProfileAsync(model);
            if (success)
            {
                TempData["SuccessMessage"] = "Profile updated successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update profile.";
            }

            return View(model);
        }
    }
}