using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("produto")]
    public partial class produto
    {
        public int Id { get; set; }

        public int Empresaid { get; set; }

        public int Usuarioid { get; set; }

        public int Codigo { get; set; }

        public string Descricao { get; set; } = null!;

        public string? Ean { get; set; }

        public string? Cest { get; set; }

        public int Unidademedidaid { get; set; }

        public int Tipoprodutoid { get; set; }

        public string? Unidadenome { get; set; }

        public int Origemid { get; set; }

        public int Categoriaid { get; set; }

        public int? Marcaid { get; set; }

        public int Ncmid { get; set; }

        public int? Marcaprodutoid { get; set; }

        public int? Anpprodutoid { get; set; }

        public virtual ICollection<compraitens> Compraitens { get; set; } = new List<compraitens>();
    }
}
