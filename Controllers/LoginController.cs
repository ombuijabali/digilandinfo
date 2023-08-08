using Geoportal.Models;
using Geoportal.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Geoportal.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public LoginController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            // Check if the user exists in the database
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == loginModel.Email);

            if (user == null)
            {
                // User does not exist, return login failure response
                return BadRequest("Invalid email or password");
            }

            if (user.Password != loginModel.Password)
            {
                // Password does not match, return login failure response
                return BadRequest("Invalid email or password");
            }

            // Retrieve the user's role from the database
            var userRole = _dbContext.Roles.SingleOrDefault(r => r.Id == user.RoleId);

            // Check if the user has one of the predefined roles ("Water", "Admin", etc.)
            if (userRole != null && (userRole.Name == "Water" || userRole.Name == "Admin"))
            {
                // Grant access based on role
                // For example, return additional data or set claims for the user's role
            }

            // Login successful, return success response
            return Ok(new { message = "Login successful" });
        }

        [HttpPost]
        [Route("api/logout")]
        public IActionResult Logout()
        {
            // Clear the user's session or token here
            // For example, if using session-based authentication:
            HttpContext.Session.Clear();

            // Return a success response
            return Ok(new { message = "Logout successful" });
        }
    }
}
