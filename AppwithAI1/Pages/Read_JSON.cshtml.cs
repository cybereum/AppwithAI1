using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace AppwithAI1.Pages



{
    public class UploadJsonModel : PageModel
    {
        [BindProperty] 
        public UploadJsonPageModel Model { get; set; }

        public UploadJsonModel(UploadJsonPageModel model)
        {
            Model = model;
            JsonData = new List<JsonDataItem>();
        }

        public List<JsonDataItem>? JsonData { get; set; }

        public class JsonDataItem
        {
            public int? Number { get; set; }
            public string? Name { get; set; }
            public int? Durations { get; set; }
            public DateTime? Start_Date { get; set; }
            public DateTime? Finish_Date { get; set; }
            public int[]? Predecessors { get; set; }
            public double? Clustering_Coefficient { get; set; }
            public double? Degree_Centrality { get; set; }
            public double? Closeness_Centrality { get; set; }
            public double? Eigenvector_Centrality { get; set; }
            public double? Page_Rank { get; set; }
            public int? Path_Centrality { get; set; }
            public bool? Dur_Outliers { get; set; }
            public bool? PagR_Outliers { get; set; }
            public bool? DegC_Outliers { get; set; }
            public bool? PthC_Outliers { get; set; }
            public double? Uncertainty { get; set; }
        }


        public IFormFile? jsonFile { get; set; }

        public void OnGet()
        {
            Model = new UploadJsonPageModel();
        }

        public IFormFile? GetJsonFile()
        {
            return jsonFile;
        }

        public void OnPost(IFormFile? jsonFile)
        {
            //if (jsonFile != null)
            {
                using (var reader = new StreamReader(stream: jsonFile.OpenReadStream()))
                {
                    string json = reader.ReadToEnd();
                    Model.JsonData = JsonConvert.DeserializeObject<List<JsonDataItem>>(json);
                }
            }
        }

        public class UploadJsonPageModel
        {
            public List<JsonDataItem>? JsonData { get; internal set; }
        }
    }
}

/*
//Gremlin portion
// create a client that connects to your Cosmos DB instance.

// Replace the values with your own Cosmos DB endpoint and key
string endpoint = "your-cosmosdb-endpoint";
string key = "your-cosmosdb-key";

// Create a Gremlin client
GremlinClient gremlinClient = new GremlinClient(endpoint, key);

//add a vertex to the graph, you can use the following code:

// Create a dictionary with the properties for the vertex
Dictionary<string, object> properties = new Dictionary<string, object>
{
    { "Number", item.Number },
    { "Name", item.Name },
    // Add other properties here
};

// Create the vertex with the given properties
var result = await gremlinClient.SubmitAsync<dynamic>("g.addV('vertex-label').property(single, 'key', 'value')", properties);

// Check the result to see if the vertex was added successfully
if (result.Count > 0)
{
    // Vertex was added successfully
}
else
{
    // There was an error adding the vertex
}

// code to add edges between vertices. For example:
// Create a dictionary with the properties for the edge
Dictionary<string, object> properties = new Dictionary<string, object>
{
    { "Durations", item.Durations },
    // Add other properties here
};

// Create the edge between the two vertices
var result = await gremlinClient.SubmitAsync<dynamic>("g.V().has('vertex-label', 'Number', vertexNumber1).addE('edge-label').to(g.V().has('vertex-label', 'Number', vertexNumber2)).property(single, 'key', 'value')", properties);

// Check the result to see if the edge was added successfully
if (result.Count > 0)
{
    // Edge was added successfully
}
else
{
    // There was an error adding the edge
}
*/

/* 
{
    public class UploadJsonPageModel
    {
        public dynamic JsonData { get; set; }

        public void OnGet()
        {
            // Do nothing
        }

        public void OnPost(HttpPostedFile jsonFile)
        {
            if (jsonFile != null)
            {
                // Read the contents of the file into a string
                string json = new StreamReader(jsonFile.InputStream).ReadToEnd();

                // Deserialize the JSON string into a dynamic object
                JsonData = new JavaScriptSerializer().Deserialize<dynamic>(json);
            }
        }
    }
}
*/

/* The model includes a JsonData property that will be used to store the deserialized JSON data. 
 * The model also includes OnGet and OnPost methods that are called when the page is requested and when the form is submitted, respectively. 
 * The OnPost method checks if a file was uploaded, reads the contents of the file into a string, and deserializes the JSON string into a dynamic object that is stored in the JsonData property
 * */




