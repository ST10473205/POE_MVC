namespace POE.Models
{
    public class EnrolmentDto
    {
        public string Username { get; set; } = string.Empty;
        public int EventId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string EmergencyContact { get; set; } = string.Empty;
    }
}
