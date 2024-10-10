using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("arquivossped")]
    public class FileData
    {
        [Key]
        public int idfile { get; set; }
        public string fileName { get; set; }
        public string contenttype { get; set; } // Tipo MIME
        public string filepath { get; set; }
        public byte[] data { get; set; } // Conteúdo binário do arquivo
        public DateTime uploadedat { get; set; } = DateTime.UtcNow;
    }
}
