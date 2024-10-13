using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("compra")]
    public class compra
    {
        public int idcompra { get; set; }

        public int empresaid { get; set; }

        public int usuarioid { get; set; }

        public int status { get; set; }

        public int origem { get; set; }

        public int tipooperacaoid { get; set; }

        public double totalnota { get; set; } = 0;

        public int volumes { get; set; } = 0;

        public double totaldesconto { get; set; } = 0;

        public double totalacrescimo { get; set; } = 0;

        public double totalfinal { get; set; } = 0;

        public int movimentofiscalid { get; set; }

        public int numeronota { get; set; }

        public string chavenota { get; set; }

        public int pessoaid { get; set; }

        public string xml { get; set; }

        public DateTime dataentrada { get; set; }

        public DateTime dataemissao { get; set; }

        public DateTime datacriacao { get; set; } = DateTime.UtcNow;

        public DateTime dataatualizacao { get; set; } = DateTime.UtcNow;

        public virtual ICollection<compraitens> Compraitens { get; set; } = new List<compraitens>();
    }

}

