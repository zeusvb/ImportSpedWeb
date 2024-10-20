using EficazFramework.SPED.Schemas.NFe;
using ImportSpedWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Estado = ImportSpedWeb.Models.Estado;

namespace ImportSpedWeb.Data
{
    public class ImportSpedContext : DbContext
    {

          

        public DbSet<usuario> usuarios { get; set; }
        public DbSet<FileData> files { get; set; }
        public DbSet<Empresas> empresa { get; set; }
        public DbSet<pessoa> pessoas { get; set; }
        public DbSet<ImportSpedWeb.Models.Compra> compras { get; set; }
        public DbSet<Compraiten> comprasitens { get; set; }
        public DbSet<produto> Produto { get; set; }
        public DbSet<municipio> Municipio { get; set; }
        public DbSet<Estado> Estado { get; set; }
        
        public DbSet<Ncm> Ncm { get; set; }
        public DbSet<Venda> Venda { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileData>(entity =>
            {
                entity.HasKey(e => e.idfiles).HasName("arquivossped_pk");
                entity.ToTable("arquivossped");
                entity.Property(e => e.idfiles).HasColumnName("idfiles");
            });

            modelBuilder.Entity<ImportSpedWeb.Models.Compra>(entity =>
            {
                entity.HasKey(e => e.Idcompra).HasName("compra_pkey");
                entity.ToTable("compra");
                entity.Property(e => e.Idcompra).HasColumnName("idcompra");
            });
            modelBuilder.Entity<Compraiten>(entity =>
            {
                entity.HasKey(e => new { e.Idcompra, e.Iditem }).HasName("compraitens_pkey");

                entity.ToTable("compraitens");

                entity.HasIndex(e => e.Compraid, "ix_compraitens_compraid");

                entity.HasIndex(e => e.Produtoid, "ix_compraitens_produtoid");

                entity.Property(e => e.Idcompra)
                    .HasDefaultValueSql("nextval('compraitens_idcompraitens_seq'::regclass)")
                    .HasColumnName("idcompra");
                entity.Property(e => e.Iditem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("iditem");
                entity.Property(e => e.Acrescimo).HasColumnName("acrescimo");
                entity.Property(e => e.Compraid).HasColumnName("compraid");
                entity.Property(e => e.Desconto).HasColumnName("desconto");
                entity.Property(e => e.Descricaoproduto)
                    .HasMaxLength(600)
                    .HasColumnName("descricaoproduto");
                entity.Property(e => e.Frete).HasColumnName("frete");
                entity.Property(e => e.Outrasdespesas).HasColumnName("outrasdespesas");
                entity.Property(e => e.Precounitario).HasColumnName("precounitario");
                entity.Property(e => e.Produtoid).HasColumnName("produtoid");
                entity.Property(e => e.Quantidade).HasColumnName("quantidade");
                entity.Property(e => e.Seguro).HasColumnName("seguro");
                entity.Property(e => e.Subtotal).HasColumnName("subtotal");
                entity.Property(e => e.Totalfinal).HasColumnName("totalfinal");
                entity.Property(e => e.Unidademedidaid)
                    .HasDefaultValue(0)
                    .HasColumnName("unidademedidaid");
                entity.Property(e => e.Valorimposto).HasColumnName("valorimposto");

                entity.HasOne(d => d.Compra).WithMany(p => p.Compraitens)
                    .HasForeignKey(d => d.Compraid)
                    .HasConstraintName("fk_compraitens_compra_compraid");

                entity.HasOne(d => d.Produto).WithMany(p => p.Compraitens)
                    .HasForeignKey(d => d.Produtoid)
                    .HasConstraintName("fk_compraitens_produtos_produtoid");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.id).HasName("empresas_pkey");
                entity.ToTable("empresas");
                entity.Property(e => e.id).HasColumnName("id");

            });

            modelBuilder.Entity<pessoa>(entity =>
            {
                entity.HasKey(e => e.id).HasName("pessoas_pkey");
                entity.ToTable("pessoas");
                entity.Property(e => e.id).HasColumnName("id");
            });

            modelBuilder.Entity<produto>(entity =>
            {
                entity.HasKey(e => e.id).HasName("produtos_pkey");
                entity.ToTable("produtos");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.empresaid).HasColumnName("empresaid");
                entity.Property(e => e.marcaid).HasColumnName("marcaid");
                entity.Property(e => e.marcaprodutoid).HasColumnName("marcaprodutoid");
                entity.Property(e => e.ncmid).HasColumnName("ncmid");
                entity.Property(e => e.origemid).HasColumnName("origemid");
                entity.Property(e => e.tipoprodutoid).HasColumnName("tipoprodutoid");
                entity.Property(e => e.unidademedidaid).HasColumnName("unidademedidaid");
                entity.Property(e => e.usuarioid).HasColumnName("usuarioid");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("estado_pkey");

                entity.ToTable("estado");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Codigoestado)
                    .HasDefaultValue(0)
                    .HasColumnName("codigoestado");
                entity.Property(e => e.DescricaoUf)
                    .HasMaxLength(100)
                    .HasColumnName("descricao_uf");
            });

            modelBuilder.Entity<municipio>(entity =>
            {
                entity.HasKey(e => e.id).HasName("municipio_pkey");

                entity.ToTable("municipio");

                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.codigoestado)
                    .HasDefaultValue(0)
                    .HasColumnName("codigoestado");
                entity.Property(e => e.codigoibge)
                    .HasColumnType("character varying")
                    .HasColumnName("codigoibge");
                entity.Property(e => e.descricao)
                    .HasMaxLength(100)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Ncm>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ncm_pkey");

                entity.ToTable("ncm");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cest)
                    .HasMaxLength(150)
                    .HasColumnName("cest");
                entity.Property(e => e.Chave)
                    .HasMaxLength(100)
                    .HasColumnName("chave");
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("codigo");
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(900)
                    .HasColumnName("descricao");
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("estado");
                entity.Property(e => e.Estadual).HasColumnName("estadual");
                entity.Property(e => e.Ex).HasColumnName("ex");
                entity.Property(e => e.Fonte)
                    .HasMaxLength(100)
                    .HasColumnName("fonte");
                entity.Property(e => e.Importadosfederal).HasColumnName("importadosfederal");
                entity.Property(e => e.Municipal).HasColumnName("municipal");
                entity.Property(e => e.Nacionalfederal).HasColumnName("nacionalfederal");
                entity.Property(e => e.Tipo).HasColumnName("tipo");
                entity.Property(e => e.Versao)
                    .HasMaxLength(100)
                    .HasColumnName("versao");
                entity.Property(e => e.Vigenciafim)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("vigenciafim");
                entity.Property(e => e.Vigenciainicio)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("vigenciainicio");
            });

            modelBuilder.Entity<Vendaitem>(entity =>
            {
                entity.HasKey(e => new { e.idvenda, e.numerosequencialitem }).HasName("vendaitem_pkey");

                entity.ToTable("vendaitem");

                entity.HasIndex(e => e.idvenda, "fki_vendaitem_venda_fk");

                entity.Property(e => e.idvenda)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idvenda");
                entity.Property(e => e.numerosequencialitem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("numerosequencialitem");
                entity.Property(e => e.abatimentosnt)
                    .HasDefaultValueSql("0")
                    .HasColumnName("abatimentosnt");
                entity.Property(e => e.aliquota_icms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("aliquota_icms");
                entity.Property(e => e.aliquota_ipi)
                    .HasDefaultValueSql("0")
                    .HasColumnName("aliquota_ipi");
                entity.Property(e => e.aliquotapercentual_cofins)
                    .HasDefaultValueSql("0")
                    .HasColumnName("aliquotapercentual_cofins");
                entity.Property(e => e.aliquotapercentual_pis)
                    .HasDefaultValueSql("0")
                    .HasColumnName("aliquotapercentual_pis");
                entity.Property(e => e.aliquotareais_cofins)
                    .HasDefaultValueSql("0")
                    .HasColumnName("aliquotareais_cofins");
                entity.Property(e => e.aliquotareais_pis)
                    .HasDefaultValueSql("0")
                    .HasColumnName("aliquotareais_pis");
                entity.Property(e => e.aliquotast_icms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("aliquotast_icms");
                entity.Property(e => e.basecalculo_cofins)
                    .HasDefaultValueSql("0")
                    .HasColumnName("basecalculo_cofins");
                entity.Property(e => e.basecalculo_icms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("basecalculo_icms");
                entity.Property(e => e.basecalculo_ipi)
                    .HasDefaultValueSql("0")
                    .HasColumnName("basecalculo_ipi");
                entity.Property(e => e.basecalculo_pis)
                    .HasDefaultValueSql("0")
                    .HasColumnName("basecalculo_pis");
                entity.Property(e => e.basecalculoquantidade_cofins)
                    .HasDefaultValueSql("0")
                    .HasColumnName("basecalculoquantidade_cofins");
                entity.Property(e => e.basecalculoquantidade_pis)
                    .HasDefaultValueSql("0")
                    .HasColumnName("basecalculoquantidade_pis");
                entity.Property(e => e.basecalculost_icms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("basecalculost_icms");
                entity.Property(e => e.cfop)
                    .HasMaxLength(50)
                    .HasColumnName("cfop");
                entity.Property(e => e.codigocontacontabil)
                    .HasMaxLength(255)
                    .HasColumnName("codigocontacontabil");
                entity.Property(e => e.codigoproduto)
                    .HasMaxLength(255)
                    .HasColumnName("codigoproduto");
                entity.Property(e => e.cst_cofins).HasColumnName("cst_cofins");
                entity.Property(e => e.cst_icms).HasColumnName("cst_icms");
                entity.Property(e => e.cst_ipi)
                    .HasMaxLength(50)
                    .HasColumnName("cst_ipi");
                entity.Property(e => e.cst_pis).HasColumnName("cst_pis");
                entity.Property(e => e.desconto)
                    .HasDefaultValueSql("0")
                    .HasColumnName("desconto");
                entity.Property(e => e.descricaocomplementaritem)
                    .HasMaxLength(255)
                    .HasColumnName("descricaocomplementaritem");
                entity.Property(e => e.enquadramento_ipi)
                    .HasMaxLength(255)
                    .HasColumnName("enquadramento_ipi");
                entity.Property(e => e.indicadormovimento).HasColumnName("indicadormovimento");
                entity.Property(e => e.naturezaoperacao)
                    .HasMaxLength(255)
                    .HasColumnName("naturezaoperacao");
                entity.Property(e => e.origem).HasColumnName("origem");
                entity.Property(e => e.quantidade)
                    .HasDefaultValueSql("0")
                    .HasColumnName("quantidade");
                entity.Property(e => e.totalitem)
                    .HasDefaultValueSql("0")
                    .HasColumnName("totalitem");
                entity.Property(e => e.unidademedida)
                    .HasMaxLength(50)
                    .HasColumnName("unidademedida");
                entity.Property(e => e.valor_cofins)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valor_cofins");
                entity.Property(e => e.valorst_icms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valor_icms");
                entity.Property(e => e.valor_ipi)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valor_ipi");
                entity.Property(e => e.valor_pis)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valor_pis");
                entity.Property(e => e.valorst_icms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorst_icms");

                entity.HasOne(d => d.IdvendaNavigation).WithMany(p => p.Vendaitems)
                    .HasForeignKey(d => d.idvenda)
                    .HasConstraintName("vendaitem_venda_fk");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(e => e.idvenda).HasName("venda_pk");

                entity.ToTable("venda");

                entity.Property(e => e.idvenda).HasColumnName("idvenda");
                entity.Property(e => e.chavenfe)
                    .HasMaxLength(44)
                    .HasColumnName("chavenfe");
                entity.Property(e => e.codigoparticipante)
                    .HasMaxLength(255)
                    .HasColumnName("codigoparticipante");
                entity.Property(e => e.dataemissao).HasColumnName("dataemissao");
                entity.Property(e => e.dataentradasaida).HasColumnName("dataentradasaida");
                entity.Property(e => e.especiedocumento)
                    .HasMaxLength(255)
                    .HasColumnName("especiedocumento");
                entity.Property(e => e.numero).HasColumnName("numero");
                entity.Property(e => e.serie)
                    .HasMaxLength(3)
                    .HasColumnName("serie");
                entity.Property(e => e.valorabatimento)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorabatimento");
                entity.Property(e => e.valorbasecalculoicms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorbasecalculoicms");
                entity.Property(e => e.valorbasecalculoicmsst)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorbasecalculoicmsst");
                entity.Property(e => e.valorcofins)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorcofins");
                entity.Property(e => e.valorcofinsst)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorcofinsst");
                entity.Property(e => e.valordesconto)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valordesconto");
                entity.Property(e => e.valorfrete)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorfrete");
                entity.Property(e => e.valoricms)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valoricms");
                entity.Property(e => e.valoricmsst)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valoricmsst");
                entity.Property(e => e.valoripi)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valoripi");
                entity.Property(e => e.valoroutrasdespesas)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valoroutrasdespesas");
                entity.Property(e => e.valorpis)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorpis");
                entity.Property(e => e.valorpisst)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorpisst");
                entity.Property(e => e.valorseguro)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valorseguro");
                entity.Property(e => e.valortotaldocumento)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valortotaldocumento");
                entity.Property(e => e.valortotalmercadorias)
                    .HasDefaultValueSql("0")
                    .HasColumnName("valortotalmercadorias");
            });

            modelBuilder.HasDefaultSchema("public");

            // OnModelCreating(modelBuilder);

        }

        public ImportSpedContext(DbContextOptions<ImportSpedContext> options)
       : base(options)
        {
           // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        static ImportSpedContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // configurationBuilder.Properties<string>().UseCollation("case_insensitive");
        }

    }
}
