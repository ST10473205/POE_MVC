using System.ComponentModel.DataAnnotations;

namespace POE_MVC.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime EventDate { get; set; } = DateTime.Now;

        [Required]
        public string Location { get; set; } = string.Empty;

        public double DistanceKm { get; set; }

        public string? ImageUrl { get; set; } // Can be null if no image is uploaded

        public bool IsEnrolled { get; set; }
    }
}