using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("pessoas")]
    public class pessoa
    {

        [Key]
        public int id { get; set; }       

        public int empresaid { get; set; }

        public int tipodocumentopessoa { get; set; }

        public string cnpj { get; set; } = "";

        public string rg { get; set; }

        public string razaosocial { get; set; }

        public string nome { get; set; }

        public int sexo { get; set; }

        public string inscricaoestadual { get; set; } = "";

        public string inscricaomunicipal { get; set; } = "";

        public bool ativo { get; set; } = true;

        public int documentoestrangeiro { get; set; } = 0;

        public string logradouro { get; set; }

        public string complemento { get; set; }

        public string numero { get; set; }

        public string bairro { get; set; }

        public string cep { get; set; }

        public int cidadeid { get; set; }

        public DateTime datacriacao { get; set; } = DateTime.UtcNow;

        public DateTime dataatualizacao { get; set; } = DateTime.UtcNow;

    }
}
