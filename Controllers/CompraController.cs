using EficazFramework.SPED.Extensions;
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
        public async Task<IActionResult> RegistrarCompra(CompraDTO compraDto)
        {

            var modelocompra = new Compra
            {
                Chavenota = compraDto.chavenota,
                Empresaid = compraDto.empresaid,
                Numeronota = compraDto.numeronota,
                Pessoaid = compraDto.pessoaid,
                Origem = compraDto.origem,
                Status = compraDto.status,
                Tipooperacaoid = compraDto.tipooperacaoid,
                Dataentrada = compraDto.dataentrada,
                Dataemissao = compraDto.dataemissao,
                Totalacrescimo = (decimal) compraDto.totalacrescimo,
                Totaldesconto =(decimal) compraDto.totaldesconto,
                Totalfinal = (decimal)compraDto.totalfinal,
                Totalnota =(decimal) compraDto.totalnota,
                Usuarioid = compraDto.usuarioid,
                Volumes = compraDto.volumes,
                Xml = compraDto.xml,
                Movimentofiscalid = compraDto.movimentofiscalid,
            };
            foreach (var it in compraDto.itenscompra)
            {
                Compraiten cit = new Compraiten();

                cit.Acrescimo = (decimal)it.acrescimo;
                cit.Produtoid = it.produtoid;
                cit.Seguro =(decimal)  it.seguro;
                cit.Frete = (decimal)it.frete;
                cit.Descricaoproduto = it.descricaoproduto;
                cit.Outrasdespesas =(decimal)  it.outrasdespesas;
                cit.Produtoid=it.produtoid;
                cit.Quantidade = (decimal)it.quantidade;
                cit.Desconto = (decimal)it.desconto;
                cit.Precounitario = (decimal)it.precounitario;
                cit.Subtotal = (decimal)it.subtotal;
                cit.Totalfinal  = (decimal)it.totalfinal;
                cit.Unidademedidaid = it.unidademedidaid;
                cit.Valorimposto = (decimal)it.valorimposto;
                cit.Iditem = it.iditem;

                modelocompra.Compraitens.Add(cit);
            }
         
            await _context.compras.AddAsync(modelocompra);
            await _context.SaveChangesAsync();

            if (modelocompra.Chavenota == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
            else
                return StatusCode(StatusCodes.Status201Created, new { idSucces = true });

        }

        [HttpGet("{idcompra::int}")]
        public async Task<IActionResult> GetcomprasId(int idcompra)
        {
            var compraRecord = await _context.compras.Where(e => e.Idcompra == idcompra).FirstOrDefaultAsync();

            if (compraRecord == null)
                return NotFound();
            

            return Ok(compraRecord);
        }

        [HttpGet("{chaveNfe}")]
        public async Task<IActionResult> GetComprachave(string chaveNfe)
        {
            var CompraRecord = await _context.compras.Where(e => e.Chavenota == chaveNfe).FirstOrDefaultAsync();

            if (CompraRecord == null)
                return NotFound();


            return Ok(CompraRecord);
        }

        [HttpGet("{EmpresaId}/{DataIcinial}/{DataFinal}")]
        public async Task<IActionResult> GetCompraData(int EmpresaId, DateTime DataIcinial, DateTime DataFinal)
        {
            var CompraRecord = await _context.compras.Where(e => e.Empresaid == EmpresaId && e.Dataentrada >= DataFinal.Date && e.Dataentrada <= DataFinal.Date).ToListAsync();

            if (CompraRecord == null)
                return NotFound();


            return Ok(CompraRecord);
        }

        [HttpDelete("{idCompra:int}")]
        public async Task<ActionResult<Compra>> DeleteCompras(int idCompra)
        {
            try
            {
                var CompraToDelete = await _context.compras.Where(c => c.Idcompra == idCompra).FirstOrDefaultAsync();

                if (CompraToDelete == null)
                {
                    return NotFound($"Compra com Id = {idCompra} não encontrada");
                }

                _context.compras.Remove(CompraToDelete);
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
