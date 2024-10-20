using EficazFramework.SPED.Schemas.NFe;
using ImportSpedWeb.Data;
using ImportSpedWeb.Models;
using ImportSpedWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ImportSpedWeb.Controllers
{
    [Authorize]
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
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not provided.");


            string applicationPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var uploadPath = Path.Combine(applicationPath, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, file.FileName);

            FileInfo Fl = new FileInfo(filePath);
            if (Fl.Exists)
            {
                Fl.Delete();
            }

            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            fileStream.Dispose();


            var fileRecord = new FileData
            {
                filename = file.FileName,
                filepath = filePath,
                contenttype = file.ContentType,
                data = ConvertToByteArray(filePath),

                status = 0
            };

            _context.files.Add(fileRecord);
            _context.SaveChanges();

            return Ok(new { FileId = fileRecord.idfiles });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var fileRecord = await _context.files.FindAsync(id);

            if (fileRecord == null)
                return NotFound();

            var fileBytes = await System.IO.File.ReadAllBytesAsync(fileRecord.filepath);
            return File(fileBytes, fileRecord.contenttype, fileRecord.filename);
        }

        private byte[] ConvertToByteArray(string filePath)
        {
            byte[] fileData;

            //Create a File Stream Object to read the data
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    fileData = reader.ReadBytes((int)fs.Length);
                }
            }

            return fileData;
        }
       
        //[HttpPost("ProssesarArquivos")]
        //public async Task<IActionResult> ProssearArquivo(string ProssesarArquivos)
        //{
        //    var FilesProcessar = await _context.files.Where(c => c.status == 0).ToListAsync();

        //    //ImportArquivo Lr = new ImportArquivo();


        //    for (int i = 0; i < FilesProcessar.Count; i++)
        //    {

        //        LerArquivo(FilesProcessar[i]);

        //    }


        //    return Ok();
        //}

        private async void LerArquivo(FileData ArqFiles)
        {


            string applicationPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var uploadPath = Path.Combine(applicationPath, "Downloads");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, ArqFiles.filename.ToString());

            FileInfo Fl = new FileInfo(filePath);
            if (Fl.Exists)
            {
                Fl.Delete();
            }

            using (var ArqTxt = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                ArqTxt.Write(ArqFiles.data, 0, ArqFiles.data.Length);

            System.IO.Stream stream = System.IO.File.OpenRead(filePath);

            EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();
            //escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
            await escrituracao.LeArquivo(stream);



        }




    }
       

    }


