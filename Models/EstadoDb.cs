using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("estado")]
    public  class Estado
    {
        public int id { get; set; }

        public int codigoestado { get; set; }

        public string descricaouf { get; set; } = "";
    }
}
