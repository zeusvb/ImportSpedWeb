
namespace ImportSpedWeb.Models
{
    public class Venda
    {

        public int idvenda { get; set; }
        public string codigoparticipante { get; set; } = null; // 4
        public string especiedocumento { get; set; } = null; // 5
      
        public string serie { get; set; } = null; // 7
        public int numero { get; set; } = default; // 8
        public string chavenfe { get; set; } = null; // 9
        public DateTime dataemissao { get; set; } = default; // 10
        public DateTime dataentradasaida { get; set; } = default; // 11
        public double valortotaldocumento { get; set; } = default; // 12
      
        public double valordesconto { get; set; } = default; // 14
        public double valorabatimento { get; set; } = default; // 15
        public double valortotalmercadorias { get; set; } = default; // 16
       
        public double valorfrete { get; set; } = default; // 18
        public double valorseguro { get; set; } = default; // 19
        public double valoroutrasdespesas { get; set; } = default; // 20
        public double valorbasecalculoicms { get; set; } = default; // 21
        public double valoricms { get; set; } = default; // 22
        public double valorbasecalculoicmsst { get; set; } = default; // 23
        public double valoricmsst { get; set; } = default; // 24
        public double valoripi { get; set; } = default; // 25
        public double valorpis { get; set; } = default; // 26
        public double valorcofins { get; set; } = default; // 27
        public double valorpisst { get; set; } = default; // 28
        public double valorcofinsst { get; set; } = default; // 29

        public virtual ICollection<Vendaitem> Vendaitems { get; set; } = new List<Vendaitem>();
    }
}
