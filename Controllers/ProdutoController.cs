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
    public class ProdutoController : ControllerBase
    {
        private readonly ImportSpedContext _context;
        private readonly IWebHostEnvironment _env; // Para obter o caminho da pasta wwwroot

        public ProdutoController(ImportSpedContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("RegistrarProduto")]
        public async Task<IActionResult> RegistrarPessoa(ProdutoDTO Produtodto)
        {

            var modeloproduto = new produto
            {
                anpprodutoid = Produtodto.anpprodutoid,
                categoriaid = Produtodto.categoriaid,
                cest = Produtodto.cest,
                descricao = Produtodto.descricao,
                ean = Produtodto.ean,
                empresaid = Produtodto.empresaid,
                marcaid = Produtodto.marcaid,
                origemid = Produtodto.origemid,
                ncmid = Produtodto.ncmid,
                marcaprodutoid = Produtodto.marcaprodutoid,
                tipoprodutoid = Produtodto.tipoprodutoid,
                unidademedidaid = Produtodto.unidademedidaid,
                unidadenome = Produtodto.unidadenome,
                usuarioid = Produtodto.usuarioid,
                codigo = Produtodto.codigo,

            };

            await _context.Produto.AddAsync(modeloproduto);
            await _context.SaveChangesAsync();

            if (modeloproduto.descricao == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
            else
                return StatusCode(StatusCodes.Status201Created, new { idSucces = true });

        }

        [HttpGet("{idProduto::int}")]
        public async Task<IActionResult> GetProdutoId(int idProduto)
        {
            var PessoaRecord = await _context.Produto.Where(e => e.id == idProduto).FirstOrDefaultAsync();

            if (PessoaRecord == null)
                return NotFound();


            return Ok(PessoaRecord);
        }

        [HttpGet("{CodigoId::int}/{IdEmpresa::int}")]
        public async Task<IActionResult> GetCodigoProduto(int CodigoId, int IdEmpresa)
        {
            var ProdutoRecord = await _context.Produto.Where(e => e.codigo == CodigoId && e.empresaid == IdEmpresa).FirstOrDefaultAsync();

            if (ProdutoRecord == null)
                return NotFound();

            return Ok(ProdutoRecord);
        }


        [HttpDelete("{idProduto:int}")]
        public async Task<ActionResult<pessoa>> DeletePessoa(int idProduto)
        {
            try
            {
                var pessoaToDelete = await _context.Produto.Where(c => c.id == idProduto).FirstOrDefaultAsync();

                if (pessoaToDelete == null)
                {
                    return NotFound($"Produto com Id = {idProduto} não encontrada");
                }

                _context.Produto.Remove(pessoaToDelete);
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
