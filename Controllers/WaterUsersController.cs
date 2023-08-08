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
    [Route("api/Water")]
    public class WaterUsersController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public WaterUsersController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MonthlyWaterData>> GetWaterUsers()
        {
            // Retrieve the water users from the database
            var waterUsers = _dbContext.WaterUsers.ToList();

            // Group water users' data by month (now client-side evaluation)
            var groupedData = waterUsers.GroupBy(u => u.PaymentDate.Month);

            // Compute the total amount paid and arrears for each month
            var monthlyWaterData = new List<MonthlyWaterData>();

            foreach (var group in groupedData)
            {
                var month = group.Key;
                var totalPaidAmount = group.Sum(u => u.PaidAmount);
                var totalBalanceAmount = group.Sum(u => u.BalanceAmount);

                monthlyWaterData.Add(new MonthlyWaterData
                {
                    Month = new DateTime(DateTime.Now.Year, month, 1),
                    PaidAmount = totalPaidAmount,
                    ArrearsAmount = totalBalanceAmount
                });
            }

            return Ok(monthlyWaterData);
        }

        // New GET method to search by plot number and return all the information for that plot number
        [HttpGet("query-by-plot-no/{plotNo}")]
        public ActionResult<IEnumerable<WaterUser>> GetWaterUsersByPlotNo(string plotNo)
        {
            // Retrieve water users with the provided plot number from the database
            var waterUsers = _dbContext.WaterUsers.Where(u => u.PlotNo == plotNo).ToList();

            return Ok(waterUsers);
        }
    }

    public class MonthlyWaterData
    {
        public DateTime Month { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ArrearsAmount { get; set; }
    }
}
