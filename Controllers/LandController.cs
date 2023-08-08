using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Geoportal.Models;
using Geoportal.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Geoportal.Controllers
{
    [ApiController]
    [Route("api/Land")]
    public class LandController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public LandController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Land
        [HttpPost]
        public IActionResult AddLand([FromBody] LandModel landModel) // Changed the parameter type to LandModel
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the land to the database
            _dbContext.Land.Add(landModel);
            _dbContext.SaveChanges();

            return Ok(landModel); // Return the added land with its database-assigned ID
        }

        // GET: api/Land/Summary
        [HttpGet("Summary")]
        public IActionResult GetSummary()
        {
            var landSummary = new
            {
                NumberOfUsers = _dbContext.Land.Count(),
                TotalAmount = _dbContext.Land.Sum(p => p.TotalAmount),
                PaidAmount = _dbContext.Land.Sum(p => p.PaidAmount),
                UnpaidAmount = _dbContext.Land.Sum(p => p.Balance)
            };

            return Ok(landSummary);
        }

        // GET: api/Land/AmountByMonth
        // GET: api/Land/AmountByMonth
        [HttpGet("AmountByMonth")]
        public IActionResult GetAmountByMonth()
        {
            var landByMonth = _dbContext.Land
                .GroupBy(p => new { Month = p.PaymentDate.Month, Year = p.PaymentDate.Year })
                .Select(group => new
                {
                    Month = new DateTime(group.Key.Year, group.Key.Month, 1),
                    TotalAmount = group.Sum(p => p.TotalAmount),
                    PaidAmount = group.Sum(p => p.PaidAmount),
                    Balance = group.Sum(p => p.Balance)
                })
                .OrderBy(entry => entry.Month)
                .ToList();

            return Ok(landByMonth);
        }

        // GET: api/Land
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandModel>>> GetAllLandModels() // Changed the return type to LandModel
        {
            var landModels = await _dbContext.Land.ToListAsync();
            return Ok(landModels);
        }
    }
}
