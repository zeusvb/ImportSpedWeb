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
           
            modelBuilder.HasDefaultSchema("public");
        }

        public DbSet<usuario> usuarios { get; set; }
        public DbSet<FileData> Files { get; set; }

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
