using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{

    [Table("compraitens")]
    public class compraitens
    {
        public int compraid { get; set; }

        public int idcompraitens { get; set; }

        public int iditem { get; set; }

        public int produtoid { get; set; }

        public string descricaoproduto { get; set; }

        public double quantidade { get; set; } = 0;

        public double precounitario { get; set; } = 0;

        public double subtotal { get; set; } = 0;

        public double desconto { get; set; } = 0;

        public double acrescimo { get; set; } = 0;

        public double frete { get; set; } = 0;

        public double outrasdespesas { get; set; } = 0;

        public double seguro { get; set; } = 0;

        public double totalfinal { get; set; } = 0;

        public int unidademedidaid { get; set; }

        public double valorimposto { get; set; } = 0;

       

    }
}
