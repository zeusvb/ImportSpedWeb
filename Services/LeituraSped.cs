using ImportSpedWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ImportSpedWeb.Services
{
    public class LeituraSped
    {
        private  async Task LeituraArquivo(IFormFile file)
        {

            var uploadPath = "";// Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, file.FileName);
            System.IO.Stream streamFile = System.IO.File.OpenRead(filePath);

            EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();

            await escrituracao.LeArquivo(streamFile);




    }
    }
       
}
