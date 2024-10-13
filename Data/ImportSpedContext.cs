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
            modelBuilder.HasDefaultSchema("public");

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
