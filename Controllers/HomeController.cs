using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Geoportal.Controllers
{
    public class HomeController : Controller
    {
        // Action method to serve the Angular app
        public IActionResult Index()
        {
            // Get the path to the index.html file in the Angular app
            string indexFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp", "dist", "index.html");

            // Read the contents of the index.html file
            string htmlContent = System.IO.File.ReadAllText(indexFilePath);

            // Return the HTML content
            return Content(htmlContent, "text/html");
        }
    }
}
