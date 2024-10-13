using ImportSpedWeb.Data;
using ImportSpedWeb.DTO;
using ImportSpedWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace ImportSpedWeb.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly ImportSpedContext _context;
        private readonly IWebHostEnvironment _env; // Para obter o caminho da pasta wwwroot

        public EmpresasController(ImportSpedContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("RegistrarEmpresa")]
        public async Task<IActionResult> RegistrarEmpresa(EmpresaDTO Empresadto)
        {
            var modeloempresa = new Empresas
            {
                razaosocial = Empresadto.razaosocial.ToString().ToUpper(),
                nomefantasia = Empresadto.nomefantasia.ToString().ToUpper(),
                regimetributarioid= Empresadto.regimetributarioid,
                cnpj= Empresadto.cnpj.ToString(),
                logradouro = Empresadto.logradouro.ToString().ToUpper(),
                complemento = Empresadto.complemento.ToString().ToUpper(),    
                numero  = Empresadto.numero.ToString(),
                bairro  = Empresadto.bairro.ToString().ToUpper(),
                cep = Empresadto.cep.ToString(),
                email   = Empresadto.email.ToString().ToLower(),
                telefone = Empresadto.telefone.ToString(),
                celular = Empresadto.celular.ToString(),
                cidadeid = Empresadto.cidadeid,
                inscricaomunicipal = Empresadto.inscricaomunicipal.ToString(),
                inscricaoestadual = Empresadto.inscricaoestadual.ToString(),
               
            };

            await _context.empresa.AddAsync(modeloempresa);
            await _context.SaveChangesAsync();

            if (modeloempresa.razaosocial == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
            else
                return StatusCode(StatusCodes.Status201Created, new { idSucces = true });

        }

        [HttpGet("{idEmpresa::int}")]
        public async Task<IActionResult> GetEmpresaId(int idEmpresa)
        {
            var EmpresaRecord = await _context.empresa.Where(e => e.empresaid == idEmpresa).FirstOrDefaultAsync();

            if (EmpresaRecord == null)
                return NotFound();


            return Ok( EmpresaRecord);
        }

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> GetEmpresaCnpj(string cnpj)
        {
            var EmpresaRecord = await _context.empresa.Where(e => e.cnpj == cnpj).FirstOrDefaultAsync();

            if (EmpresaRecord == null)
                return NotFound();


            return Ok(EmpresaRecord);
        }

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<Empresas>> UpdateEmpresa(int id, Empresas empresa)
        //{
        //    try
        //    {
        //        if (id != empresa.empresaid)
        //        {
        //            return BadRequest("Employee ID mismatch");
        //        }

        //        var empresaToUpdate = await _context.empresa.Where(c => c.empresaid == id).FirstOrDefaultAsync();

        //        if (empresaToUpdate == null)
        //        {
        //            return NotFound($"Employee with Id = {id} not found");
        //        }

        //        return await _context.empresa.Update (empresa);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error updating data");
        //    }
        //}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Empresas>> DeleteEmpresa(int id)
        {
            try
            {
                var empresaToDelete = await _context.empresa.Where(c => c.empresaid == id).FirstOrDefaultAsync();

                if (empresaToDelete == null)
                {
                    return NotFound($"Empresa com Id = {id} não encontrada");
                }

                _context.empresa.Remove(empresaToDelete);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error ao deletar registro");
            }
        }
        
    }
}
