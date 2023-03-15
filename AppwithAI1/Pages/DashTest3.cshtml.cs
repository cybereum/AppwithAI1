using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Remote;
using Gremlin.Net.Structure.IO.GraphSON;
using Microsoft.Graph;


/*
namespace AppwithAI1.Pages
{
    public class DashTest3Model : PageModel
    {
        
        private static string hostname = "wss://cosmosgremlinapi.documents.azure.com:443/";
        private static int port = 443;
        private static string authkey = "lja6Gkeuf5nsnEg9TYyC79N1fvt4v1ZBb9JwkbWPNiNC1tEeBOSVu8vBHQZeKnSFguIKz9ziKjVEiPAjRAuf3w==";
        private static string database = "graphdb";
        private static string collection = "Graph8";

        
        public void MainMethod()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Connecting to Cosmos DB Gremlin API...");
            var gremlinServer = new GremlinServer(hostname, port, enableSsl: true,
                username: "/dbs/" + database + "/colls/" + collection,
                password: authkey);
            using (var gremlinClient = new GremlinClient(gremlinServer, new GraphSON2Reader(), new GraphSON2Writer(), GremlinClient.GraphSON2MimeType))
            {
                Task<ResultSet<dynamic>> query = gremlinClient.SubmitAsync<dynamic>("g.V().hasLabel('Milestones')");
                ResultSet<dynamic> result = query.Result;
                foreach (dynamic item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
        
        public class Milestone
        {
            public string? id { get; set; }
            public string? Number { get; set; }
            public string? name { get; set; }
            public string? Start_Date { get; set; }
            public string? Finish_Date { get; set; }
            public List<string>? Predecessors { get; set; }
            public string? Durations { get; set; }
        }
    }
}
*/