using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("arquivossped")]
    public class FileData
    {
        [Key]
        public int idfiles { get; set; }
        public string filename { get; set; } = "";
        public string contenttype { get; set; } = "";// Tipo MIME
        public string filepath { get; set; } = "";
        public byte[] data { get; set; } // Conteúdo binário do arquivo
        public int status { get; set; } = 0;
      //  public DateTime uploadedat { get; set; } = DateTime.UtcNow;
    }
}
