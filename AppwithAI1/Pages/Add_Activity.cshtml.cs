/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Cosmos.Table.Queryable;
using Microsoft.Azure.Documents.Client;
using System;
using System.Linq;
using System.Web.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppwithAI1.Pages
{
    public class GANTTDataModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TaskName { get; set; }
        public int TaskDuration { get; set; }
    }

    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult CreateGraph(GANTTDataModel model)
        {
            // Retrieve the connection string for the Cosmos DB Gremlin endpoint
            string connectionString = "<<CONNECTION STRING>>";

            // Connect to the Cosmos DB Gremlin endpoint
            GremlinServer gremlinServer = new GremlinServer(
                connectionString,
                port: 443,
                enableSsl: true,
                username: "/dbs/<<DATABASE NAME>>/colls/<<COLLECTION NAME>>",
                password: "<<SECRET KEY>>"
            );

            // Create a GremlinClient instance
            GremlinClient gremlinClient = new GremlinClient(gremlinServer, new GraphSON2Reader(), new GraphSON2Writer(), GremlinClient.GraphSON2MimeType);

            // Upload the form data to Cosmos DB Gremlin
            gremlinClient.Submit("g.addV('task').property('startDate', '" + model.StartDate + "')"
                                   + ".property('endDate', '" + model.EndDate + "')"
                                   + ".property('taskName', '" + model.TaskName + "')"
                                   + ".property('taskDuration', '" + model.TaskDuration + "')");

            return View();
        }
    }
}


using Microsoft.Azure.CosmosDB.Gremlin;
using Microsoft.Azure.CosmosDB.BulkExecutor;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Threading.Tasks;

namespace AppwithAI1.Pages
{
    public class GANTTDataModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaskName { get; set; }
        public int TaskDuration { get; set; }
    }

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace AppwithAI1.Pages
    {
        public class GANTTDataModel
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string TaskName { get; set; }
            public int TaskDuration { get; set; }
        }

        public class HomeController : Controller
        {
            private readonly IConfiguration _configuration;
            private CosmosClient _cosmosClient;

            public HomeController(IConfiguration configuration)
            {
                _configuration = configuration;
                string cosmosDbEndpoint = _configuration["CosmosDbEndpoint"];
                string cosmosDbKey = _configuration["CosmosDbKey"];

                CosmosClientBuilder clientBuilder = new CosmosClientBuilder(cosmosDbEndpoint, cosmosDbKey);
                _cosmosClient = clientBuilder.Build();
            }

            [HttpPost]
            public async Task<IActionResult> CreateGraph(GANTTDataModel model)
            {
                string databaseName = _configuration["CosmosDbDatabaseName"];
                string containerName = _configuration["CosmosDbContainerName"];

                Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
                Container container = await database.CreateContainerIfNotExistsAsync(containerName, "/id");

                var task = new
                {
                    id = Guid.NewGuid().ToString(),
                    startDate = model.StartDate,
                    endDate = model.EndDate,
                    taskName = model.TaskName,
                    taskDuration = model.TaskDuration
                };

                ItemResponse<object> response = await container.CreateItemAsync<object>(task, new PartitionKey(task.id));
                return RedirectTo



/*
To upload the data from the form in the cshtml file to Cosmos DB, you will need to create an ASP.NET cshtml.cs file that contains the necessary code to connect to the Cosmos DB database and execute a Gremlin query.

Here is an example of what the cshtml.cs file might look like: */


using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Cosmos;

namespace AppwithAI1.Pages
        {
            public class GANTTDataModel : PageModel
            {
                [BindProperty]
                public DateTime StartDate { get; set; }

                [BindProperty]
                public DateTime EndDate { get; set; }

                [BindProperty]
                public string TaskName { get; set; }

                [BindProperty]
                public int TaskDuration { get; set; }

                public async Task<IActionResult> OnPostAsync()
                {
                    // Retrieve the Cosmos DB endpoint and key from the appsettings.json file
                    var endpoint = Environment.GetEnvironmentVariable("COSMOS_DB_ENDPOINT");
                    var key = Environment.GetEnvironmentVariable("COSMOS_DB_KEY");

                    // Create a Cosmos DB client
                    var client = new CosmosClient(endpoint, key);

                    // Retrieve the database and graph from the Cosmos DB instance
                    var database = client.GetDatabase("myDatabase");
                    var graph = database.GetGraph("myGraph");

                    // Create a new vertex for the task in the graph
                    var taskVertex = graph.CreateVertex("task");
                    taskVertex.SetProperty("name", TaskName);
                    taskVertex.SetProperty("startDate", StartDate);
                    taskVertex.SetProperty("endDate", EndDate);
                    taskVertex.SetProperty("duration", TaskDuration);
                    await taskVertex.SaveAsync();

                    // Redirect to the index page
                    return RedirectToPage("Index");
                }
            }
        }

