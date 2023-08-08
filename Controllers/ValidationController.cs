using Geoportal.DbContext;
using Geoportal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace traffic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public ValidationController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("confirm-id")]
        public IActionResult ConfirmID(string id, string plotNumber)
        {
            // Perform the necessary validation logic here
            // Compare the provided ID number with the plot number

            // Assuming you have a DbSet<ValidationModel> named "Validations" in your GeoportalDbContext
            var validation = _dbContext.Validations.FirstOrDefault(v => v.IDNumber == id && v.PlotNumber == plotNumber);

            if (validation != null)
            {
                // ID number and plot number match, return a success response
                return Ok();
            }
            else
            {
                // ID number and plot number do not match, return an error response
                return BadRequest("Invalid ID number or plot number.");
            }
        }
    }
}
