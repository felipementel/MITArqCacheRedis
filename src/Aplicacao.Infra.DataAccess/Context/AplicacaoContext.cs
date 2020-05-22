using Aplicacao.Domain.Model;
using Aplicacao.Infra.DataAccess.Map;
using Aplicacao.Infra.DataAccess.Seed;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aplicacao.Infra.DataAccess.Context
{
    public class AplicacaoContext : DbContext
    {
        public AplicacaoContext(DbContextOptions<AplicacaoContext> options)
           : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Map
            modelBuilder.ApplyConfiguration(new ClienteMap());

            //Seed
            modelBuilder.ApplyConfiguration(new ClienteSeed());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //if (!optionsBuilder.IsConfigured)
            //{                
            //    IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory()) //Microsoft.Extensions.Configuration.FileExtensions
            //    .AddJsonFile("appsettings.json") //Microsoft.Extensions.Configuration.Json
            //    .Build();

            //    var connectionString = configuration.GetConnectionString("Aplicacao");
            //    optionsBuilder.UseSqlServer(connectionString, x => x.EnableRetryOnFailure())
            //    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //}
        }
    }
}