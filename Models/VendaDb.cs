
namespace ImportSpedWeb.Models
{
    public class Venda
    {
      
        public string CodigoParticipante { get; set; } = null; // 4
        public string EspecieDocumento { get; set; } = null; // 5
      
        public string Serie { get; set; } = null; // 7
        public int Numero { get; set; } = default; // 8
        public string ChaveNFe { get; set; } = null; // 9
        public DateTime DataEmissao { get; set; } = default; // 10
        public DateTime DataEntradaSaida { get; set; } = default; // 11
        public double ValorTotalDocumento { get; set; } = default; // 12
      
        public double ValorDesconto { get; set; } = default; // 14
        public double ValorAbatimento { get; set; } = default; // 15
        public double ValorTotalMercadorias { get; set; } = default; // 16
       
        public double ValorFrete { get; set; } = default; // 18
        public double ValorSeguro { get; set; } = default; // 19
        public double ValorOutrasDespesas { get; set; } = default; // 20
        public double ValorBaseCalculoICMS { get; set; } = default; // 21
        public double ValorICMS { get; set; } = default; // 22
        public double ValorBaseCalculoICMSST { get; set; } = default; // 23
        public double ValorICMSST { get; set; } = default; // 24
        public double ValorIPI { get; set; } = default; // 25
        public double ValorPIS { get; set; } = default; // 26
        public double ValorCofins { get; set; } = default; // 27
        public double ValorPISST { get; set; } = default; // 28
        public double ValorCofinsST { get; set; } = default; // 29
    }
}
