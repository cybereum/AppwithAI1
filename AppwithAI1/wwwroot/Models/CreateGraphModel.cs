namespace AppwithAI1.wwwroot.Models
{
    public class CreateGraphModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TaskName { get; set; }
        public int TaskDuration { get; set; }
        public string? PrecedingActivities { get; set; }
    }
}
