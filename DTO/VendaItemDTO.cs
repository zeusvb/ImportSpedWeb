using ImportSpedWeb.Models;

namespace ImportSpedWeb.DTO
{
    public class VendaItemDTO
    {
       public int numerosequencialitem { get; set; }
        public string codigoproduto { get; set; }
        public string descricaocomplementaritem { get; set; }
        public double quantidade { get; set; }
        public string unidademedida { get; set; }
        public double totalitem { get; set; }
        public double desconto { get; set; }
        public bool indicadormovimento { get; set; }
        public int origem { get; set; }
        public int cst_icms { get; set; }
        public string cfop { get; set; }
        public string naturezaoperacao { get; set; }
        public double basecalculo_icms { get; set; }
        public double aliquota_icms { get; set; }
        public double valor_icms { get; set; }
        public double basecalculost_icms { get; set; }
        public double aliquotast_icms { get; set; }
        public double valorst_icms { get; set; }
        public string cst_ipi { get; set; }
        public string enquadramento_ipi { get; set; }
        public double basecalculo_ipi { get; set; }
        public double aliquota_ipi { get; set; }
        public double valor_ipi { get; set; }
        public int cst_pis { get; set; } = 0;
        public double basecalculo_pis { get; set; }
        public double basecalculoquantidade_pis { get; set; }
        public double aliquotapercentual_pis { get; set; }
        public double aliquotareais_pis { get; set; }
        public double valor_pis { get; set; }
        public int cst_cofins { get; set; }
        public double basecalculo_cofins { get; set; }
        public double basecalculoquantidade_cofins { get; set; }
        public double aliquotapercentual_cofins { get; set; }
        public double aliquotareais_cofins { get; set; }
        public double valor_cofins { get; set; }
        public string codigocontacontabil { get; set; }
        public double abatimentosnt { get; set; }

        public virtual VendaDTO IdvendaNavigation { get; set; }
    }
}
