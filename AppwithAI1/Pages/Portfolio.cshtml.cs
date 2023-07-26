using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic; // Needed for List<T>

namespace AppwithAI1.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly ILogger<PortfolioModel> _logger;

        public List<Project> Projects { get; set; } // Property for storing a list of projects

        public PortfolioModel(ILogger<PortfolioModel> logger) // Initialize the logger in the constructor
        {
            _logger = logger;
            LoadDummyData(); // Call the method to load dummy data
        }

        public class Project
        {
            public string ProjectId { get; set; }
            public string ProjectName { get; set; }
            public string ProjectDescription { get; set; }
            public string ProjectManager { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string ProjectStatus { get; set; }
            public string CompletionStatus { get; set; }
            public string ProjectPhase { get; set; } 
            public string ProjectRiskLevel { get; set; } 
        }


        private void LoadDummyData()
        {
            var phases = new[] { "Initiation", "Planning", "Execution", "Closure" };
            var risks = new[] { "Low Risk", "Medium Risk", "High Risk", "Critical Risk" };
            Random rnd = new Random();

            Projects = new List<Project>
            {
                new Project { ProjectId = "1", ProjectName = "Project 1", ProjectDescription = "Description of Project 1", ProjectManager = "John Doe", StartDate = DateTime.Parse("2022-01-01"), EndDate = DateTime.Parse("2022-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "2", ProjectName = "Project 2", ProjectDescription = "Description of Project 2", ProjectManager = "Jane Doe", StartDate = DateTime.Parse("2022-02-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "40%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "3", ProjectName = "Project 3", ProjectDescription = "Description of Project 3", ProjectManager = "Alice Smith", StartDate = DateTime.Parse("2023-01-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "90%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "4", ProjectName = "Project 4", ProjectDescription = "Description of Project 4", ProjectManager = "Bob Smith", StartDate = DateTime.Parse("2023-02-01"), EndDate = DateTime.Parse("2023-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "5", ProjectName = "Project 5", ProjectDescription = "Description of Project 5", ProjectManager = "Charlie Brown", StartDate = DateTime.Parse("2023-03-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "80%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "6", ProjectName = "Project 6", ProjectDescription = "Description of Project 6", ProjectManager = "Diana Prince", StartDate = DateTime.Parse("2023-04-01"), EndDate = DateTime.Parse("2023-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "7", ProjectName = "Project 7", ProjectDescription = "Description of Project 7", ProjectManager = "Elon Musk", StartDate = DateTime.Parse("2023-05-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "60%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "8", ProjectName = "Project 8", ProjectDescription = "Description of Project 8", ProjectManager = "Fiona Apple", StartDate = DateTime.Parse("2023-06-01"), EndDate = DateTime.Parse("2023-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "9", ProjectName = "Project 9", ProjectDescription = "Description of Project 9", ProjectManager = "Gordon Ramsay", StartDate = DateTime.Parse("2023-07-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "40%" , ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)]},
                new Project { ProjectId = "10", ProjectName = "Project 10", ProjectDescription = "Description of Project 10", ProjectManager = "Hannah Montana", StartDate = DateTime.Parse("2023-08-01"), EndDate = DateTime.Parse("2023-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "11", ProjectName = "Project 11", ProjectDescription = "Description of Project 11", ProjectManager = "Iggy Pop", StartDate = DateTime.Parse("2023-09-01"), EndDate = null, ProjectStatus = "Ongoing" , CompletionStatus = "60%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)]},
                new Project { ProjectId = "12", ProjectName = "Project 12", ProjectDescription = "Description of Project 12", ProjectManager = "John Cena", StartDate = DateTime.Parse("2023-10-01"), EndDate = DateTime.Parse("2023-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "13", ProjectName = "Project 13", ProjectDescription = "Description of Project 13", ProjectManager = "Katy Perry", StartDate = DateTime.Parse("2023-11-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "35%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "14", ProjectName = "Project 14", ProjectDescription = "Description of Project 14", ProjectManager = "LeBron James", StartDate = DateTime.Parse("2023-12-01"), EndDate = DateTime.Parse("2023-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "15", ProjectName = "Project 15", ProjectDescription = "Description of Project 15", ProjectManager = "Mickey Mouse", StartDate = DateTime.Parse("2024-01-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "30%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "16", ProjectName = "Project 16", ProjectDescription = "Description of Project 16", ProjectManager = "Neymar Jr", StartDate = DateTime.Parse("2024-02-01"), EndDate = DateTime.Parse("2024-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "18", ProjectName = "Project 18", ProjectDescription = "Description of Project 18", ProjectManager = "Prince Harry", StartDate = DateTime.Parse("2024-04-01"), EndDate = DateTime.Parse("2024-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "19", ProjectName = "Project 19", ProjectDescription = "Description of Project 19", ProjectManager = "Quincy Jones", StartDate = DateTime.Parse("2024-05-01"), EndDate = null, ProjectStatus = "Ongoing", CompletionStatus = "40%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] },
                new Project { ProjectId = "20", ProjectName = "Project 20", ProjectDescription = "Description of Project 20", ProjectManager = "Rihanna", StartDate = DateTime.Parse("2024-06-01"), EndDate = DateTime.Parse("2024-12-31"), ProjectStatus = "Completed", CompletionStatus = "100%", ProjectPhase = phases[rnd.Next(phases.Length)], ProjectRiskLevel = risks[rnd.Next(risks.Length)] }
            };

        }

        public void OnGet()
        {
            _logger.LogInformation("Portfolio page requested.");
        }
    }



}
