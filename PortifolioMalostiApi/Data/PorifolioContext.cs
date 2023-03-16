using Microsoft.EntityFrameworkCore;
using PortifolioMalostiApi.Model;

namespace PortifolioMalostiApi.Data
{
    public class PorifolioContext : DbContext
    {
        public PorifolioContext(DbContextOptions<PorifolioContext> options)
            : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
