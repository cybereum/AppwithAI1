using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppwithAI1.Pages
{
    public class DashTest2Model : PageModel
    {
        public List<Activity> Activities { get; set; } = new List<Activity>();

        public void OnGet()
        {
            // Your code here
        }

        public class Activity
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public List<int>? Predecessors { get; set; }
            public List<int>? Successors { get; set; }
        }
    }

}
