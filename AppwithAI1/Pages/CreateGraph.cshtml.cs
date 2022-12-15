using AppwithAI1.Pages;
using System;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace AppwithAI1.Controllers
{

    public class CreateGraphModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TaskName { get; set; }
        public int TaskDuration { get; set; }
        public string? PrecedingActivities { get; set; }
    }


    public class HomeController1 : Controller
    {
        // Replace these values with your Cosmos DB endpoint and key
        private const string EndpointUri = "https://your-cosmos-db-endpoint.com";
        private const string PrimaryKey = "your-primary-key";
        private CosmosClient cosmosClient;

        public HomeController1()
        {
            cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
        }

        public ActionResult CreateGraph()
        {
            var model = new CreateGraphModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGraph(CreateGraphModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Connect to the "GANTT" database and "Tasks" container
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync("GANTT");
            Container container = await database.CreateContainerIfNotExistsAsync("Tasks", "/id");

            // Create a new task document
            dynamic task = new
            {
                id = Guid.NewGuid().ToString(),
                startDate = model.StartDate,
                endDate = model.EndDate,
                taskName = model.TaskName,
                taskDuration = model.TaskDuration
            };

            // Add the task document to the container
            await container.CreateItemAsync(task, new PartitionKey(task.id));

            return RedirectToAction("Index", "Home");
        }
    }
}
