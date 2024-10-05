using ImportSpedWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ImportSpedWeb.Data
{
    public class ImportSpedContext : DbContext
    {
        internal readonly IEnumerable<object> usuario;

        public ImportSpedContext()
        {
        }  

        public ImportSpedContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<usuario> usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // configurationBuilder.Properties<string>().UseCollation("case_insensitive");
        }

    }
}
