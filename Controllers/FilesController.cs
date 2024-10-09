using ImportSpedWeb.Data;
using ImportSpedWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ImportSpedWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly ImportSpedContext _context;
        private readonly IWebHostEnvironment _env; // Para obter o caminho da pasta wwwroot

        public FilesController(ImportSpedContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("uploadFilesSped")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not provided.");

            var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, file.FileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            var fileRecord = new FileData
            {
                fileName = file.FileName,
                filepath = filePath,
                contenttype = file.ContentType
            };

            _context.Files.Add(fileRecord);
            await _context.SaveChangesAsync();

            return Ok(new { FileId = fileRecord.idfile });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var fileRecord = await _context.Files.FindAsync(id);

            if (fileRecord == null)
                return NotFound();

            var fileBytes = await System.IO.File.ReadAllBytesAsync(fileRecord.filepath);
            return File(fileBytes, fileRecord.contenttype, fileRecord.fileName);
        }
    }


}
