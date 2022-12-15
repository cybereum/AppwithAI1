/*
using CosmosDbConnector;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents.Client;



namespace CosmosDbConnector
{
    public class CosmosDbGremlinService
    {
        private string EndpointUrl { get; set; }
        private string PrimaryKey { get; set; }
        private DocumentClient Client { get; set; }
        public CosmosDbGremlinService(string endpointUrl, string primaryKey)
        {
            EndpointUrl = endpointUrl;
            PrimaryKey = primaryKey;
            Client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
        }

        // Connect to the specified Cosmos DB graph
        public async Task<Graph> ConnectAsync(string database, string graph)
        {
            var databaseUri = UriFactory.CreateDatabaseUri(database);
            var graphUri = UriFactory.CreateDocumentCollectionUri(database, graph);
            var graphConnection = new GraphConnection(Client, graphUri);
            await graphConnection.ConnectAsync();
            return new Graph(graphConnection);
        }

        // Execute a Gremlin query and return the results
    public async Task<List<Vertex>> ExecuteQueryAsync(Graph graph, string query)
    {
        var gremlinQuery = graph.Traversal().WithRemote(new GremlinServer("localhost", 8182, "g"));
        var queryResult = await gremlinQuery.
            V().
            ToListAsync();
        return queryResult;
    }
}

*/

// Usage example:
/*
CosmosDbGremlinService service = new CosmosDbGremlinService(endpointUrl, primaryKey);
Graph graph = await service.ConnectAsync(database, graph);
List<Vertex> vertices = await service.ExecuteQueryAsync(graph, "g.V()");
foreach (var vertex in vertices)
{
    Console.WriteLine(vertex.Id);
}

*/