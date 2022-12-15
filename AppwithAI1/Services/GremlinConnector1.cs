
using Microsoft.AspNetCore.Mvc;
using global::AppwithAI1.Controllers;
using Microsoft.Azure.Cosmos;
// using Microsoft.Azure.Cosmos.Table;
// using Microsoft.Azure.Graphs;
// using Microsoft.Azure.Graphs.Elements;
using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Exceptions;
using System.Threading.Tasks;

namespace AppwithAI1.Services
{
    public class GremlinConnector1
    {
        private readonly string endpointUrl;
        private readonly string primaryKey;
        private readonly string databaseName;
        private readonly string graphName;

        public GremlinConnector1(string endpointUrl, string primaryKey, string databaseName, string graphName)
        {
            this.endpointUrl = endpointUrl;
            this.primaryKey = primaryKey;
            this.databaseName = databaseName;
            this.graphName = graphName;
        }

        public async Task AddVertexAsync(CreateGraphModel model)
        {
            // Connect to the Gremlin server using Gremlin.Net.Driver
            var gremlinServer = new GremlinServer(endpointUrl, port: 8182, enableSsl: true,
                                                  username: "/dbs/" + databaseName + "/colls/" + graphName,
                                                  password: primaryKey);
            using (var gremlinClient = new GremlinClient(gremlinServer))
            {
                try
                {
                    // Add the vertex to the graph
                    var gremlinQuery = "g.addV('" + model.TaskName + "')" +
                                       ".property('startDate', '" + model.StartDate + "')" +
                                       ".property('endDate', '" + model.EndDate + "')" +
                                       ".property('duration', '" + model.TaskDuration + "')" +
                                       ".property('precedingActivities', '" + model.PrecedingActivities + "')";
                    var results = await gremlinClient.SubmitAsync<dynamic>(gremlinQuery);
                }
                catch (ResponseException ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine(ex.StatusCode);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}




/*This version uses Microsoft.Azure.Graphs */

/*
using Microsoft.AspNetCore.Mvc;
using global::AppwithAI1.Controllers;
using Microsoft.Azure.Cosmos
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Graphs;
using Microsoft.Azure.Graphs.Elements;
using System.Threading.Tasks;

namespace AppwithAI1.Services
{
    public class GremlinConnector1
    {
        private readonly string endpointUrl;
        private readonly string primaryKey;
        private readonly string databaseName;
        private readonly string graphName;

        public GremlinConnector1(string endpointUrl, string primaryKey, string databaseName, string graphName)
        {
            this.endpointUrl = endpointUrl;
            this.primaryKey = primaryKey;
            this.databaseName = databaseName;
            this.graphName = graphName;
        }

        public async Task AddVertexAsync(CreateGraphModel model)
        {
            var client = new GraphClient(new Uri(endpointUrl), primaryKey);
            await client.ConnectAsync();

            var graph = client.Graphs[databaseName, graphName];
            var vertex = new Vertex(model.TaskName, new
            {
                startDate = model.StartDate,
                endDate = model.EndDate,
                duration = model.TaskDuration,
                precedingActivities = model.PrecedingActivities
            });
            await graph.AddVertexAsync(vertex);
        }
    }
}
*/

/*
 * The GremlinConnector1 class accepts the following parameters in its constructor:

endpointUrl: The URL of the Cosmos DB endpoint.
primaryKey: The primary key for the Cosmos DB account.
databaseName: The name of the Cosmos DB database.
graphName: The name of the Gremlin graph.
The AddVertexAsync method is used to add a new vertex to the Gremlin graph using the data from the CreateGraphModel object. It creates a new Vertex object with the TaskName property as the vertex id and the StartDate, EndDate, TaskDuration, and PrecedingActivities properties as the vertex properties. 
It then adds the vertex to the Gremlin graph using the AddVertexAsync method.

To use the GremlinConnector1 class in your ASP.NET project, you need to first add a reference to the Microsoft.Azure.Graphs and Microsoft.Azure.Cosmos.Table NuGet packages.

Then, you can inject an instance of the GremlinConnector1 class into the controller that handles the form submission, and use the AddVertexAsync method to add a vertex to the Gremlin graph using the data from the form, like this:

using Microsoft.AspNetCore.Mvc;
using AppwithAI1.Services;

namespace AppwithAI1.Controllers
{
    public class HomeController : Controller
    {
        private readonly GremlinConnector1 gremlinConnector1;

        public HomeController(GremlinConnector1 gremlinConnector1)
        {
            this.gremlinConnector1 = gremlinConnector1;
        }

        [HttpPost]
        public
 
 
 
 */
