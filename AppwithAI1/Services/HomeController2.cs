using Microsoft.AspNetCore.Mvc;
using AppwithAI1.Services;
// using AppwithAI1.wwwroot.Models;

namespace AppwithAI1.Controllers
{
    public class HomeController2 : Controller
    {
        private readonly GremlinConnector1 gremlinConnector1;

        public HomeController2(GremlinConnector1 gremlinConnector1)
        {
            this.gremlinConnector1 = gremlinConnector1;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Rename the CreateGraph method to have a unique name
        [HttpPost]
        public async Task<IActionResult> CreateNewGraph(CreateGraphModel model)
        {
            await gremlinConnector1.AddVertexAsync(model);

            return View("Index");
        }
    }
}


/*
 * The HomeController class has two actions: Index and CreateGraph. The Index action is responsible for rendering the GANTT chart creation form when the user navigates to the home page. The CreateGraph action is responsible for handling the form submission and adding a vertex to the Cosmos DB Gremlin graph using the GremlinConnector1 service.

To use this controller in your ASP.NET project, you will need to add a reference to the Microsoft.Azure.Graphs and Microsoft.Azure.Graphs.Elements NuGet packages. You will also need to register the GremlinConnector1 service with the ASP.NET dependency injection container, so that it can be injected into the HomeController class.
*/