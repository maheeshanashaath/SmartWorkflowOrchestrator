namespace Orchestrator.Data.Models
{
    public class Workflow
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
