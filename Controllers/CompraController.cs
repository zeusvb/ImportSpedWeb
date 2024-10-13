using ImportSpedWeb.Data;
using ImportSpedWeb.DTO;
using ImportSpedWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ImportSpedWeb.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ImportSpedContext _context;
        private readonly IWebHostEnvironment _env; // Para obter o caminho da pasta wwwroots

        public CompraController(ImportSpedContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("RegistrarCompra")]
        public async Task<IActionResult> RegistrarPessoa(CompraDTO compraDto)
        {

            var modelocompra = new compra
            {
                chavenota = compraDto.chavenota,
                empresaid = compraDto.empresaid,
                numeronota = compraDto.numeronota,
                pessoaid = compraDto.pessoaid,
                origem = compraDto.origem,
                status = compraDto.status,
                tipooperacaoid = compraDto.tipooperacaoid,
                dataentrada = compraDto.dataentrada,
                dataemissao = compraDto.dataemissao,
                totalacrescimo = compraDto.totalacrescimo,
                totaldesconto = compraDto.totaldesconto,
                totalfinal = compraDto.totalfinal,
                totalnota = compraDto.totalnota,
                usuarioid = compraDto.usuarioid,
                volumes = compraDto.volumes,
                xml = compraDto.xml,
                movimentofiscalid = compraDto.movimentofiscalid,

             
            };
            foreach (var it in compraDto.itenscompra)
            {
                compraitens cit = new compraitens();

                cit.acrescimo = it.acrescimo;
                cit.produtoid = it.produtoid;
                cit.seguro = it.seguro;
                cit.frete = it.frete;
                cit.descricaoproduto = it.descricaoproduto;
                cit.outrasdespesas = it.outrasdespesas;
                cit.produtoid=it.produtoid;
                cit.quantidade = it.quantidade;
                cit.desconto = it.desconto;
                cit.precounitario = it.precounitario;
                cit.subtotal = it.subtotal;
                cit.totalfinal  = it.totalfinal;
                cit.unidademedidaid = it.unidademedidaid;
                cit.valorimposto = it.valorimposto;
                cit.iditem = it.iditem;

                modelocompra.itenscompra.Add(cit);

            }
         
            await _context.compras.AddAsync(modelocompra);
            await _context.SaveChangesAsync();

            if (modelocompra.chavenota == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
            else
                return StatusCode(StatusCodes.Status201Created, new { idSucces = true });

        }

        [HttpGet("{idcompra::int}")]
        public async Task<IActionResult> GetcomprasId(int idcompra)
        {
            var compraRecord = await _context.compras.Where(e => e.idcompra == idcompra).FirstOrDefaultAsync();

            if (compraRecord == null)
                return NotFound();
            

            return Ok(compraRecord);
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
