using Geoportal.DbContext;
using Geoportal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geoportal.Controllers
{
    [ApiController]
    [Route("api/Revenue")]
    public class RevenueController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public RevenueController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetRevenue()
        {
            // Get all the revenue data from the database
            var allRevenue = _dbContext.Revenue.ToList();

            // Group the revenue data by month
            var revenueByMonth = allRevenue
                .GroupBy(r => new { r.Date.Year, r.Date.Month })
                .Select(g => new
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    PaidAmount = g.Sum(r => r.Paid),
                    UnpaidAmount = g.Sum(r => r.Unpaid),
                    DefaultedAmount = g.Sum(r => r.Defaulted)
                })
                .OrderBy(g => g.Month)
                .ToList();

            // Create a list to hold the aggregated revenue data
            var aggregatedRevenue = new List<Revenue>();

            // Convert the grouped data to RevenueData objects
            foreach (var entry in revenueByMonth)
            {
                aggregatedRevenue.Add(new Revenue
                {
                    Month = entry.Month,
                    RevenueCollected = entry.PaidAmount,
                    PendingPayments = entry.UnpaidAmount + entry.DefaultedAmount
                });
            }

            return Ok(aggregatedRevenue);
        }
    }
}
