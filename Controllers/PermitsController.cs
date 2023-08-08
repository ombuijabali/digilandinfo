using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Geoportal.Models;
using Geoportal.DbContext;
using Microsoft.EntityFrameworkCore; // Add this using directive for ToListAsync()

namespace Geoportal.Controllers
{
    [ApiController]
    [Route("api/Permits")]
    public class PermitsController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public PermitsController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Permits
        [HttpPost]
        public IActionResult AddPermit([FromBody] PermitsModel permit) // Changed the parameter type to PermitsModel
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the permit to the database
            _dbContext.Permits.Add(permit);
            _dbContext.SaveChanges();

            return Ok(permit); // Return the added permit with its database-assigned ID
        }

        // GET: api/Permits/AmountByMonth
        [HttpGet("AmountByMonth")]
        public IActionResult GetAmountByMonth()
        {
            var permitsByMonth = _dbContext.Permits
                .GroupBy(p => new { Month = p.PaymentDate.Month, Year = p.PaymentDate.Year })
                .Select(group => new
                {
                    Month = new DateTime(group.Key.Year, group.Key.Month, 1),
                    Amount = group.Sum(p => p.Amount)
                })
                .OrderBy(entry => entry.Month)
                .ToList();

            return Ok(permitsByMonth);
        }

        // GET: api/Permits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermitsModel>>> GetAllPermits()
        {
            var permits = await _dbContext.Permits.ToListAsync();
            return Ok(permits);
        }
    }
}
