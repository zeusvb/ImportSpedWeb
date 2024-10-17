using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("municipio")]
    public  class municipio
    {
        [Key]
        public int id { get; set; }

        public string? codigoibge { get; set; }

        public string? descricao { get; set; }

        public int codigoestado { get; set; }
    }
}
