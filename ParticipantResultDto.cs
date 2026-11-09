namespace POE_MVC.Models
{
    public class ParticipantResultDto
    {
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string FinishTime { get; set; } = string.Empty;
        public int Position { get; set; }
        public int TotalFinishers { get; set; }
    }
}
