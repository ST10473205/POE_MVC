using System.ComponentModel.DataAnnotations;

namespace POE_MVC.Models
{
    public class CreateEnrolmentViewModel
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please select a race category.")]
        public string CategoryName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency contact number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string EmergencyContact { get; set; } = string.Empty;
    }
}
