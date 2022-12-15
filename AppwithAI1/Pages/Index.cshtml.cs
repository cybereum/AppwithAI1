using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppwithAI1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}

/*
 * <script>
    // Import required libraries
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // Set up connection to Cosmos db
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("YOUR_COSMOS_DB_CONNECTION_STRING");
    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    CloudTable table = tableClient.GetTableReference("YOUR_TABLE_NAME");
    table.CreateIfNotExistsAsync().Wait();

    // Load the csv file
    using (var reader = new StreamReader("https://cybereum.io/wp-content/uploads/2021/04/force4.csv"))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');

            // Create new graph vertex with task, startDate, and endDate properties
            var vertex = new Vertex("task", values[0], "startDate", values[1], "endDate", values[2]);

            // Add vertex to Cosmos db graph
            table.ExecuteAsync(TableOperation.InsertOrMerge(vertex)).Wait();
        }
    }
</script>
 */ 