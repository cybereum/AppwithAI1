using Microsoft.Azure.Cosmos.Fluent;
using System;
using System.Threading.Tasks;


/*
namespace GanttChartService
{
    public class CreateGANTTService
    {
        private CosmosClient _cosmosClient;
        public CreateGANTTService(string endpoint, string key)
        {
            _cosmosClient = new CosmosClientBuilder(endpoint, key)
                .WithGremlinEndpoint()
                .Build();
        }

        public async Task CreateGanttChart(string chartName)
        {
            try
            {
                // Create a new Gantt chart vertex in the Cosmos database
                await _cosmosClient.CreateGremlinQuery<dynamic>("g", $"g.addV('GanttChart').property('id', '{chartName}')").ExecuteNextAsync();
            }
            catch (CosmosException ex)
            {
                Console.WriteLine($"Error creating Gantt chart: {ex.Message}");
            }
        }
    }
}
*/