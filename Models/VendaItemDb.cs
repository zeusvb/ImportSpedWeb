
namespace ImportSpedWeb.Models
{
    public class Vendaitem
    {
        public int idvenda { get; set; }
        public int NumeroSequencialItem { get; set; }
        public string CodigoProduto { get; set; }
        public string DescricaoComplementarItem { get; set; }
        public double Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public double TotalItem { get; set; }
        public double Desconto { get; set; }
        public bool IndicadorMovimento { get; set; }
        public int Origem { get; set; }
        public int CST_ICMS { get; set; }
        public string CFOP { get; set; }
        public string NaturezaOperacao { get; set; }
        public double BaseCalculo_ICMS { get; set; }
        public double Aliquota_ICMS { get; set; }
        public double Valor_ICMS { get; set; }
        public double BaseCalculoST_ICMS { get; set; }
        public double AliquotaST_ICMS { get; set; }
        public double ValorST_ICMS { get; set; }
        public string CST_IPI { get; set; }
        public string Enquadramento_IPI { get; set; }
        public double BaseCalculo_IPI { get; set; }
        public double Aliquota_IPI { get; set; }
        public double Valor_IPI { get; set; }
        public int CST_PIS { get; set; } = 0;
        public double BaseCalculo_PIS { get; set; }
        public double BaseCalculoQuantidade_PIS { get; set; }
        public double AliquotaPercentual_PIS { get; set; }
        public double AliquotaReais_PIS { get; set; }
        public double Valor_PIS { get; set; }
        public int CST_COFINS { get; set; }
        public double BaseCalculo_COFINS { get; set; }
        public double BaseCalculoQuantidade_COFINS { get; set; }
        public double AliquotaPercentual_COFINS { get; set; }
        public double AliquotaReais_COFINS { get; set; }
        public double Valor_COFINS { get; set; }
        public string CodigoContaContabil { get; set; }
        public double AbatimentosNT { get; set; }
    }

}
