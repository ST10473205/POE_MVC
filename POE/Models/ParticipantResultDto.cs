namespace POE.Models
{
    public class ParticipantResultDto
    {
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string FinishTime { get; set; } = string.Empty; // e.g., "01:42:15"
        public int Position { get; set; }
        public int TotalFinishers { get; set; }
    }
}
