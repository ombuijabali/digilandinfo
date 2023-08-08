using Geoportal.DbContext;
using Geoportal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Geoportal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelsController : ControllerBase
    {
        private readonly GeoportalDbContext _dbContext;

        public ParcelsController(GeoportalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{idNumber}")]
        public IActionResult GetParcelById(int idNumber)
        {
            var parcel = _dbContext.Parcels.FirstOrDefault(p => p.ID_Number == idNumber);

            if (parcel == null)
            {
                return NotFound();
            }

            return Ok(parcel);
        }
        [HttpGet("plot/{plotNumber}")]
        public IActionResult GetParcelByPlotNumber(string plotNumber)
        {
            var parcel = _dbContext.Parcels.FirstOrDefault(p => p.Plot_No == plotNumber);

            if (parcel == null)
            {
                return NotFound();
            }

            return Ok(parcel);
        }
    }
}
