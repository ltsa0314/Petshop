using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PetShop.Domain.SeedWork.Enumns;
using PetShop.Infraestructure.Data.Contexts;
using System;

namespace PetShop.Infraestructure.Data
{
    public class PetShopContexFactory :
        IDesignTimeDbContextFactory<PetShopContext>,
        IDesignTimeDbContextFactory<PetShopSqlServerContext>,
        IDesignTimeDbContextFactory<PetShopOracleContext>

    {
        public PetShopContext CreateDbContext(string[] args)
        {
            var provider = DataBaseProvider.InMemory;
            var conectionString = nameof(PetShopContext);

            return CreateProvider(conectionString, provider);
        }

        PetShopSqlServerContext IDesignTimeDbContextFactory<PetShopSqlServerContext>.CreateDbContext(string[] args)
        {
            var provider = DataBaseProvider.SQLServer;
            var config = GetConfiguration(AppContext.BaseDirectory, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            var conectionString = config.GetConnectionString(provider.ToString());
            return (PetShopSqlServerContext)CreateProvider(conectionString, provider);
        }

        PetShopOracleContext IDesignTimeDbContextFactory<PetShopOracleContext>.CreateDbContext(string[] args)
        {
            var provider = DataBaseProvider.Oracle;
            var config = GetConfiguration(AppContext.BaseDirectory, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            var conectionString = config.GetConnectionString(provider.ToString());
            return (PetShopOracleContext)CreateProvider(conectionString, provider);
        }

        public static PetShopContext Create()
        {
            var config = GetConfiguration(AppContext.BaseDirectory, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            var provider = config["Provider"];
            var conectionString = config.GetConnectionString(provider.ToString());

            if (string.IsNullOrEmpty(provider))
                throw new ArgumentException("Debe especificar un proveedor de base de datos");

            if (!Enum.TryParse(provider, out DataBaseProvider providerDB))
                throw new ArgumentException("Proveedor de base de datos no esta Soportado. solo se soporta InMemory, SQLServer");

            return CreateProvider(conectionString, providerDB);

        }

        private static PetShopContext CreateProvider(string conectionString, DataBaseProvider provider)
        {
            PetShopContext context = null;
            if (string.IsNullOrEmpty(conectionString))
                throw new ArgumentException("No pudo encontrar una cadena de conexión");

            var optionsBuilder = new DbContextOptionsBuilder<PetShopContext>();

            switch (provider)
            {
                case DataBaseProvider.InMemory:
                    optionsBuilder.UseInMemoryDatabase(databaseName: nameof(PetShopContext))
                        .EnableSensitiveDataLogging()
                        .UseLazyLoadingProxies();

                    context = new PetShopContext(optionsBuilder.Options);
                    break;
                case DataBaseProvider.SQLServer:
                    optionsBuilder.UseSqlServer(conectionString)
                        .EnableSensitiveDataLogging();
                        //.UseLazyLoadingProxies();
                    context = new PetShopSqlServerContext(optionsBuilder.Options);
                    context.Database.Migrate();
                    break;
                case DataBaseProvider.Oracle:
                    optionsBuilder.UseOracle(conectionString)
                        .EnableSensitiveDataLogging()
                        .UseLazyLoadingProxies();
                    context = new PetShopOracleContext(optionsBuilder.Options);
                    context.Database.Migrate();
                    break;
            }
         
            return context;
        }

        private static IConfigurationRoot GetConfiguration(string basePath, string environment)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings{environment}.json", true)
            .AddEnvironmentVariables();

            return builder.Build();
        }


    }
}
