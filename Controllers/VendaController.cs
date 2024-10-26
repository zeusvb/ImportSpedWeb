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
    public class VendaController : ControllerBase
    {
        private readonly ImportSpedContext _context;
        private readonly IWebHostEnvironment _env; // Para obter o caminho da pasta wwwroots

        public VendaController(ImportSpedContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("RegistrarVenda")]
        public async Task<IActionResult> RegistrarVenda(VendaDTO VendaDto)
        {

            var modeloVenda = new Venda
            {
                chavenfe = VendaDto.chavenfe,
                codigoparticipante = VendaDto.codigoparticipante,
                dataemissao = VendaDto.dataemissao,
                dataentradasaida = VendaDto.dataentradasaida,
                empresaid = VendaDto.empresaid,
                especiedocumento = VendaDto.especiedocumento,
                numero = VendaDto.numero,
                serie = VendaDto.serie,
                valorabatimento = VendaDto.valorabatimento,
                valorbasecalculoicms = VendaDto.valorbasecalculoicms,
                valorbasecalculoicmsst = VendaDto.valorbasecalculoicmsst,
                valorcofins = VendaDto.valorcofins,
                valorcofinsst = VendaDto.valorcofinsst,
                valordesconto = VendaDto.valordesconto,
                valorfrete = VendaDto.valorfrete,
                valoricms = VendaDto.valoricms,
                valoricmsst = VendaDto.valoricmsst,
                valoripi = VendaDto.valoripi,
                valoroutrasdespesas = VendaDto.valoroutrasdespesas,
                valorpis = VendaDto.valorpis,
                valorpisst = VendaDto.valorpisst,
                valorseguro = VendaDto.valorseguro,
                valortotaldocumento = VendaDto.valortotaldocumento,
                valortotalmercadorias = VendaDto.valortotalmercadorias,

            };
            foreach (var it in VendaDto.Vendaitem)
            {
                Vendaitem i = new Vendaitem();

                i.abatimentosnt = it.abatimentosnt;
                i.aliquotapercentual_cofins=it.aliquotapercentual_cofins;
                i.aliquotapercentual_pis = it.aliquotapercentual_pis;
                i.aliquotareais_cofins = it.aliquotareais_cofins;
                i.aliquotareais_pis = it.aliquotareais_pis;
                i.aliquotast_icms = it.aliquotast_icms;
                i.aliquota_icms = it.aliquota_icms;
                i.aliquota_ipi = it.aliquota_ipi;
                i.codigoproduto = it.codigoproduto;
                i.aliquotapercentual_cofins = it.aliquotapercentual_cofins;
                i.basecalculost_icms = it.basecalculo_icms;
                i.basecalculo_icms = it.basecalculo_icms;
                i.basecalculo_ipi = it.basecalculo_ipi;
                i.basecalculo_pis = it.basecalculo_pis;
                i.cfop = it.cfop;
                i.cst_cofins = it.cst_cofins;
                i.desconto = it.desconto;
                i.descricaocomplementaritem = it.descricaocomplementaritem;
                i.naturezaoperacao = it.naturezaoperacao;
                i.numerosequencialitem = it.numerosequencialitem;
                i.origem = it.origem;
                i.quantidade = it.quantidade;
                i.unidademedida = it.unidademedida;
                i.totalitem = it.totalitem;
                i.valorst_icms = it.valorst_icms;
                i.valor_cofins = it.valor_cofins;
                i.valor_icms = it.valor_icms;
                i.valor_pis = it.valor_pis;
                i.valor_cofins = it.valor_cofins;
                i.valor_ipi = it.valor_ipi;

                modeloVenda.Vendaitems.Add(i);


            }

            await _context.Venda.AddAsync(modeloVenda);
            await _context.SaveChangesAsync();

            if (modeloVenda.chavenfe == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
            else
                return StatusCode(StatusCodes.Status201Created, new { idSucces = true });

        }

        [HttpGet("{idVenda::int}")]
        public async Task<IActionResult> GetVendaId(int idVenda)
        {
            var compraRecord = await _context.Venda.Where(e => e.idvenda == idVenda).FirstOrDefaultAsync();

            if (compraRecord == null)
                return NotFound();


            return Ok(compraRecord);
        }

        [HttpGet("{EmpresaId}/{DataIcinial}/{DataFinal}")]
        public async Task<IActionResult> GetVendaData(int EmpresaId, DateTime DataIcinial, DateTime DataFinal)
        {
            var CompraRecord = await _context.Venda.Where(e => e.empresaid == EmpresaId && e.dataentradasaida >= DataFinal.Date && e.dataentradasaida <= DataFinal.Date).ToListAsync();

            if (CompraRecord == null)
                return NotFound();


            return Ok(CompraRecord);
        }

        [HttpGet("{chaveNfe}")]
        public async Task<IActionResult> GetEmpresachave(string chaveNfe)
        {
            var CompraRecord = await _context.Venda.Where(e => e.chavenfe == chaveNfe).FirstOrDefaultAsync();

            if (CompraRecord == null)
                return NotFound();


            return Ok(CompraRecord);
        }

        [HttpDelete("{idVenda:int}")]
        public async Task<ActionResult<Venda>> DeleteCompras(int idVenda)
        {
            try
            {
                var CompraToDelete = await _context.Venda.Where(c => c.idvenda == idVenda).FirstOrDefaultAsync();

                if (CompraToDelete == null)
                {
                    return NotFound($"Venda com Id = {idVenda} não encontrada");
                }

                _context.Venda.Remove(CompraToDelete);
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
