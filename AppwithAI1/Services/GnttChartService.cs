using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

using Microsoft.Azure.Cosmos.Fluent;
/*
using Microsoft.Azure.Graphs;
using Microsoft.Azure.Cosmos.Gremlin.Fluent;
*/

/*
namespace GanttChartService
{
    public class GanttChartDataService
    {
        private CosmosClient _cosmosClient;
        public GanttChartDataService(string endpoint, string key)
        {
            _cosmosClient = new CosmosClientBuilder(endpoint, key)
                .WithGremlinEndpoint()
                .Build();
        }

        public async Task<List<GanttChartTask>> GetTasks()
        {
            List<GanttChartTask> tasks = new List<GanttChartTask>();

            IDocumentQuery<dynamic> query = _cosmosClient.CreateGremlinQuery<dynamic>("g", "g.V()");

            while (query.HasMoreResults)
            {
                foreach (dynamic vertex in await query.ExecuteNextAsync())
                {
                    tasks.Add(new GanttChartTask
                    {
                        Name = vertex.name,
                        StartDate = vertex.startDate,
                        EndDate = vertex.endDate,
                        Duration = vertex.duration,
                        Color = vertex.color
                    });
                }
            }

            return tasks;
        }
    }


}


// Replace with your Cosmos DB account information
string cosmosDbEndpoint = "https://mycosmosdbaccount.documents.azure.com:443/";
string cosmosDbAuthKey = "mycosmosdbkey";
string cosmosDbDatabase = "mydatabase";
string cosmosDbGraph = "mygraph";

// Create CosmosDB client
CosmosClient client = new CosmosClient(cosmosDbEndpoint, cosmosDbAuthKey);

// Create BulkExecutor
BulkExecutor graphBulkExecutor = new GraphBulkExecutor(client, cosmosDbDatabase, cosmosDbGraph);

// Create vertices to insert
Vertex[] vertices = new Vertex[] {
new Vertex("vertex1", new Dictionary<string, object> {
{"property1", "value1"},
{"property2", "value2"}
}),
new Vertex("vertex2", new Dictionary<string, object> {
{"property1", "value3"},
{"property2", "value4"}
})
};

// Create edges to insert
Edge[] edges = new Edge[] {
new Edge("vertex1", "edge1", "vertex2", new Dictionary<string, object> {
{"property1", "value5"},
{"property2", "value6"}
})
};


5 / 5







*/