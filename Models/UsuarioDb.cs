using EficazFramework.SPED.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;

namespace ImportSpedWeb.Models
{
    [Table("usuario")]
    public class usuario
    {
        [Key]
        public Int16 usuario_id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime dt_cad { get;  set; } = DateTime.UtcNow;
        public DateTime dt_alt { get; set; }= DateTime.UtcNow;



    }
}
