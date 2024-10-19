using EficazFramework.SPED.Schemas.NFe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{

    [Table("compraitens")]
    public partial class Compraiten
    {
        public int Idcompra { get; set; }

        public int Iditem { get; set; }

        public int Produtoid { get; set; }

        public string Descricaoproduto { get; set; } = "";

        public decimal Quantidade { get; set; }

        public decimal Precounitario { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Desconto { get; set; } = 0;

        public decimal Acrescimo { get; set; } = 0;

        public decimal Frete { get; set; } = 0;

        public decimal Outrasdespesas { get; set; } = 0;

        public decimal Seguro { get; set; } = 0;

        public decimal Totalfinal { get; set; } = 0;

        public int Compraid { get; set; }

        public int Unidademedidaid { get; set; }

        public decimal Valorimposto { get; set; }

        public virtual ImportSpedWeb.Models.Compra Compra { get; set; }

        public virtual ImportSpedWeb.Models.produto Produto { get; set; }


    }
}
