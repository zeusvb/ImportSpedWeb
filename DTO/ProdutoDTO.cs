using ImportSpedWeb.Models;

namespace ImportSpedWeb.DTO
{
    public partial class ProdutoDTO
    {
     
        public int empresaid { get; set; }

        public int usuarioid { get; set; }

        public int codigo { get; set; }

        public string descricao { get; set; } = null!;

        public string ean { get; set; } = "";

        public string cest { get; set; } = "";

        public int unidademedidaid { get; set; }

        public int tipoprodutoid { get; set; }

        public string? unidadenome { get; set; }

        public int origemid { get; set; }

        public int categoriaid { get; set; }

        public int? marcaid { get; set; }

        public int ncmid { get; set; }

        public int? marcaprodutoid { get; set; }

        public int? anpprodutoid { get; set; }
    }
}
