using EficazFramework.SPED.Schemas.NFe;
using ImportSpedWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ImportSpedWeb.Data
{
    public class ImportSpedContext : DbContext
    {
        //internal readonly IEnumerable<object> usuario;

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usuario>().Property(c => c.usuario_id).IsRequired();
            modelBuilder.Entity<FileData>().Property(c => c.idfile).IsRequired();

            modelBuilder.Entity<FileData>(entity =>
            {
                entity.HasKey(e => e.idfile).HasName("arquivossped_pk");
                entity.ToTable("arquivossped");
                entity.Property(e => e.idfile).HasColumnName("idfiles");
            });

            modelBuilder.Entity<compra>(entity =>
            {
                entity.HasKey(e => e.idcompra).HasName("compra_pkey");
                entity.ToTable("compra");
                entity.Property(e => e.idcompra).HasColumnName("idcompra");
            });
            modelBuilder.Entity<compraitens>(entity =>
            {
                entity.HasKey(e => new { e.idcompraitens, e.iditem }).HasName("compraitens_pkey");
                entity.ToTable("compraitens");
                entity.HasIndex(e => e.compraid, "ix_compraitens_compraid");
                entity.HasIndex(e => e.produtoid, "ix_compraitens_produtoid");
                entity.Property(e => e.idcompraitens)
                .ValueGeneratedOnAdd()
                .HasColumnName("idcompraitens");
                entity.Property(e => e.iditem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("iditem");
                entity.HasOne(d => d.Compra).WithMany(p => p.Compraitens)
                    .HasForeignKey(d => d.compraid)
                    .HasConstraintName("fk_compraitens_compra_compraid");
                entity.HasOne(d => d.Produto).WithMany(p => p.Compraitens)
                    .HasForeignKey(d => d.produtoid)
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
                entity.HasKey(e => e.Id).HasName("produtos_pkey");
                entity.ToTable("produtos");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Empresaid).HasColumnName("empresaid");
                entity.Property(e => e.Marcaid).HasColumnName("marcaid");
                entity.Property(e => e.Marcaprodutoid).HasColumnName("marcaprodutoid");
                entity.Property(e => e.Ncmid).HasColumnName("ncmid");
                entity.Property(e => e.Origemid).HasColumnName("origemid");
                entity.Property(e => e.Tipoprodutoid).HasColumnName("tipoprodutoid");
                entity.Property(e => e.Unidademedidaid).HasColumnName("unidademedidaid");
                entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");
            });


            modelBuilder.HasDefaultSchema("public");

            OnModelCreating(modelBuilder);

        }

        public DbSet<usuario> usuarios { get; set; }
        public DbSet<FileData> files { get; set; }
        public DbSet<Empresas> empresa { get; set; }
        public DbSet<pessoa> pessoas { get; set; }
        public DbSet<compra> compras { get; set; }
        public DbSet<compraitens> comprasitens { get; set; }


        public ImportSpedContext(DbContextOptions<ImportSpedContext> options)
       : base(options)
        {
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
