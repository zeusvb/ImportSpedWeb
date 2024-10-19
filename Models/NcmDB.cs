namespace ImportSpedWeb.Models
{
  
        public  class Ncm
        {
                public int Id { get; set; }

            public string Codigo { get; set; } = "";

            public string Descricao { get; set; } = "";

            public string Estado { get; set; } = "";

            public int? Ex { get; set; }

            public int Tipo { get; set; }

            public decimal Nacionalfederal { get; set; }

            public decimal Importadosfederal { get; set; }

            public decimal Estadual { get; set; }

            public decimal Municipal { get; set; }

            public DateTime Vigenciainicio { get; set; }

            public DateTime Vigenciafim { get; set; }

            public string Chave { get; set; }

            public string Versao { get; set; }

            public string Fonte { get; set; }

            public string Cest { get; set; }
        }
    }
