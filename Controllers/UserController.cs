using Geoportal.Models;
using Geoportal.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Geoportal.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class UserController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public UserController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("generaluser")]
        public IActionResult RegisterGeneralUser([FromBody] UsersModel userModel)
        {
            // Implement registration logic for GeneralUser role here
            // Set the role based on the name
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == "GeneralUser");
            if (role == null)
            {
                return BadRequest("GeneralUser role not found.");
            }

            userModel.RoleId = role.Id;

            // Rest of the registration logic...

            return Ok("GeneralUser registered successfully.");
        }

        [HttpPost("admin")]
        public IActionResult RegisterAdmin([FromBody] UsersModel userModel)
        {
            // Implement registration logic for Admin role here
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (role == null)
            {
                return BadRequest("Admin role not found.");
            }

            userModel.RoleId = role.Id;

            // Rest of the registration logic...

            return Ok("Admin registered successfully.");
        }

        [HttpPost("professional")]
        public IActionResult RegisterProfessional([FromBody] UsersModel userModel)
        {
            // Implement registration logic for Professional role here
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == "Professional");
            if (role == null)
            {
                return BadRequest("Professional role not found.");
            }

            userModel.RoleId = role.Id; 

            // Rest of the registration logic...

            return Ok("Professional registered successfully.");
        }

        [HttpPost("finance")]
        public IActionResult RegisterFinance([FromBody] UsersModel userModel)
        {
            // Implement registration logic for Professional role here
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == "Finance");
            if (role == null)
            {
                return BadRequest("Finance role not found.");
            }

            userModel.RoleId = role.Id;

            // Rest of the registration logic...

            return Ok("Finance registered successfully.");
        }

        // Similar methods for other roles...

        // Add access controls here if needed  AdmiN2023Digireg
    }
}
