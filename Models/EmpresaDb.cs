using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{

    [Table("empresas")]
    public class Empresas
    {
        [Key]
        public int id { get; set; }

        public int empresaid { get; set; }

        public string razaosocial { get; set; }

        public string nomefantasia { get; set; }

        public int regimetributarioid { get; set; } = 0;

        public string cnpj { get; set; }

        public string logradouro { get; set; }

        public string complemento { get; set; }

        public string numero { get; set; }

        public string bairro { get; set; }

        public string cep { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string celular { get; set; }

        public string inscricaomunicipal { get; set; } = "";

        public string inscricaoestadual { get; set; } = "";

        public int cidadeid { get; set; }

        public DateTime datacriacao { get; set; } = DateTime.UtcNow;

        public DateTime dataatualizacao { get; set; } = DateTime.UtcNow;

    }
}
