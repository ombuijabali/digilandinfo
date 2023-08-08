using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geoportal.Models;
using Geoportal.DbContext;

namespace Geoportal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly GeoportalDbContext _context;

        public SurveyController(GeoportalDbContext context)
        {
            _context = context;
        }

        // GET: api/Survey/{idNumber}
        [HttpGet("{idNumber}")]
        public async Task<ActionResult<SurveyModel>> GetSurvey(string idNumber)
        {
            var survey = await _context.Survey.FirstOrDefaultAsync(s => s.ID_Number == idNumber);

            if (survey == null)
            {
                return NotFound();
            }

            var xCoordinates = await _context.Survey
                .Where(s => s.ID_Number == idNumber)
                .Select(s => s.X_Coordinate)
                .ToArrayAsync();

            var yCoordinates = await _context.Survey
                .Where(s => s.ID_Number == idNumber)
                .Select(s => s.Y_Coordinate)
                .ToArrayAsync();

            var surveyModel = new SurveyModel
            {
                ID_Number = survey.ID_Number,
                First_Name = survey.First_Name,
                Last_Name = survey.Last_Name,
                Plot_No = survey.Plot_No,
                Plot_Size = survey.Plot_Size,
                Sheet_No = survey.Sheet_No,
                Block_No = survey.Block_No,
                X_Coordinates = xCoordinates,
                Y_Coordinates = yCoordinates
            };

            return surveyModel;
        }
    }
}
