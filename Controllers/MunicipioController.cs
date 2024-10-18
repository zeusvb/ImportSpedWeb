using ImportSpedWeb.Data;
using ImportSpedWeb.DTO;
using ImportSpedWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImportSpedWeb.Controllers
{
   
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipioController : ControllerBase
    {
        private readonly ImportSpedContext _context;
        private readonly IWebHostEnvironment _env; // Para obter o caminho da pasta wwwroot

        public MunicipioController(ImportSpedContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpGet("{IbgeMunicipio}")]
        public async Task<IActionResult> GetMunicipioIbge(string IbgeMunicipio)
        {
            var EmpresaRecord = await _context.Municipio.Where(e => e.codigoibge == IbgeMunicipio).FirstOrDefaultAsync();

            if (EmpresaRecord == null)
                return NotFound();


            return Ok(EmpresaRecord);
        }

        [HttpGet("{NomeMunicipio::required}")]
        public async Task<IActionResult> GetMunicipio(string NomeMunicipio)
        {

            var EmpresaRecord = await _context.Municipio.Where(e => EF.Functions.Like(e.descricao.ToString().ToLower(), "%" + NomeMunicipio.ToUpper() + "%")).ToListAsync();
            if (EmpresaRecord == null)
                return NotFound();


            return Ok(EmpresaRecord);
        }

        [HttpGet("{idMunicipio::int}")]
        public async Task<IActionResult> GetMunicipioId(int idMunicipio)
        {
            var EmpresaRecord = await _context.Municipio.Where(e => e.id == idMunicipio).FirstOrDefaultAsync();

            if (EmpresaRecord == null)
                return NotFound();


            return Ok(EmpresaRecord);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var MunicipioRecord = await _context.Municipio.ToListAsync();

            if (MunicipioRecord == null)
                return NotFound();


            return Ok(MunicipioRecord);
        }

        //[HttpGet]
        //public async Task<IEnumerable<municipio>> GetMunicipio()
        //{

        //    return await _context.Municipio.ToListAsync();
        //}


        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Empresas>> DeleteEmpresa(int id)
        //{
        //    try
        //    {
        //        var empresaToDelete = await _context.empresa.Where(c => c.empresaid == id).FirstOrDefaultAsync();

        //        if (empresaToDelete == null)
        //        {
        //            return NotFound($"Empresa com Id = {id} não encontrada");
        //        }

        //        _context.empresa.Remove(empresaToDelete);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error ao deletar registro");
        //    }
        //}

    }
}
