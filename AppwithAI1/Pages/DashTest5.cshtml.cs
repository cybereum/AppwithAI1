using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppwithAI1.Pages
{
    public class DashTest5Model : PageModel
    {
        public class Project
        {
            private string? id1;
            public string? Id { get; set; }
            public string? name { get; set; }
            public string? Location { get; set; }
            public string? Company { get; set; }
            public string? Type { get; set; }
            public List<string>? Members { get; set; }
            public List<ProjectMilestone>? Milestones { get; set; }
        }

        public class ProjectMilestone
        {
            public string? Number { get; set; }
            public string? Name { get; set; }
            public string? Start_Date { get; set; }
            public string? Finish_Date { get; set; }
            public List<string>? Predecessors { get; set; }
            public int Durations { get; set; }
        }
    }
}
