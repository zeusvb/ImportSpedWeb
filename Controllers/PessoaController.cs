using EficazFramework.SPED.Schemas.Primitives;
using ImportSpedWeb.Data;
using ImportSpedWeb.DTO;
using ImportSpedWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ImportSpedWeb.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ImportSpedContext _context;
        private readonly IWebHostEnvironment _env; // Para obter o caminho da pasta wwwroot

        public PessoaController(ImportSpedContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("RegistrarPessoa")]
        public async Task<IActionResult> RegistrarPessoa(PessoaDTO Pessoadto)
        {
            var modelopessoa = new pessoa
            {
                razaosocial = Pessoadto.razaosocial.ToString().ToUpper(),
                nome = Pessoadto.nome.ToString().ToUpper(),
                cnpj = Pessoadto.cnpj.ToString(),
                logradouro = Pessoadto.logradouro.ToString().ToUpper(),
                complemento = Pessoadto.complemento.ToString().ToUpper(),
                numero = Pessoadto.numero.ToString(),
                bairro = Pessoadto.bairro.ToString().ToUpper(),
                cep = Pessoadto.cep.ToString(),
                inscricaomunicipal = Pessoadto.inscricaomunicipal.ToString(),
                inscricaoestadual = Pessoadto.inscricaoestadual.ToString(),
                cidadeid = Pessoadto.cidadeid,
                rg = Pessoadto.rg.ToString(),
                sexo  = Pessoadto.sexo,
                tipodocumentopessoa = Pessoadto.tipodocumentopessoa,
                ativo = Pessoadto.ativo,
                empresaid = Pessoadto.empresaid,

            };

            await _context.pessoas.AddAsync(modelopessoa);
            await _context.SaveChangesAsync();

            if (modelopessoa.razaosocial == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
            else
                return StatusCode(StatusCodes.Status201Created, new { idSucces = true });

        }

        [HttpGet("{idPessoa::int}")]
        public async Task<IActionResult> GetPessoaId(int idPessoa)
        {
            var PessoaRecord = await _context.pessoas.Where(e => e.id == idPessoa).FirstOrDefaultAsync();

            if (PessoaRecord == null)
                return NotFound();
           

            return Ok(PessoaRecord);
        }

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> GetEmpresaCnpj(string cnpj)
        {
            var EmpresaRecord = await _context.pessoas.Where(e => e.cnpj == cnpj).FirstOrDefaultAsync();

            if (EmpresaRecord == null)
                return NotFound();


            return Ok(EmpresaRecord);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<pessoa>> DeletePessoa(int id)
        {
            try
            {
                var pessoaToDelete = await _context.pessoas.Where(c => c.empresaid == id).FirstOrDefaultAsync();

                if (pessoaToDelete == null)
                {
                    return NotFound($"Pessoa com Id = {id} não encontrada");
                }

                _context.pessoas.Remove(pessoaToDelete);
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
