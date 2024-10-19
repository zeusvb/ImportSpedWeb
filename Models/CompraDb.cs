using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportSpedWeb.Models
{
    [Table("compra")]
    public partial class Compra
    {
        public int Idcompra { get; set; }

        public int Empresaid { get; set; }

        public int Usuarioid { get; set; }

        public DateTime Dataentrada { get; set; }

        public DateTime Dataemissao { get; set; }

        public DateTime Datacriacao { get; set; }

        public DateTime Dataatualizacao { get; set; }

        public int Status { get; set; }

        public int Origem { get; set; }

        public int Tipooperacaoid { get; set; }

        public decimal Totalnota { get; set; }

        public int Volumes { get; set; }

        public decimal Totaldesconto { get; set; }

        public decimal Totalacrescimo { get; set; }

        public decimal Totalfinal { get; set; }

        public int Movimentofiscalid { get; set; }

        public int Numeronota { get; set; }

        public string Chavenota { get; set; }= "";

        public int Pessoaid { get; set; }

        public string Xml { get; set; } = "";

        public virtual ICollection<Compraiten> Compraitens { get; set; } = new List<Compraiten>();
    }

}

