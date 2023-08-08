using Geoportal.DbContext;
using Geoportal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace Geoportal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly GeoportalDbContext _context;

        public DocumentsController(GeoportalDbContext context)
        {
            _context = context;
        }

        [HttpGet("{serialNumber}")]
        public async Task<ActionResult<DocumentsModel>> GetDocument(string serialNumber)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.SerialNumber == serialNumber);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadDocument(IFormFile file, [FromForm] string serialNumber)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] documentBytes = memoryStream.ToArray();

                var newDocument = new DocumentsModel
                {
                    SerialNumber = serialNumber,
                    DocumentContent = documentBytes
                };

                _context.Documents.Add(newDocument);
                await _context.SaveChangesAsync();

                return Ok("Document uploaded successfully.");
            }
        }
    }
}
