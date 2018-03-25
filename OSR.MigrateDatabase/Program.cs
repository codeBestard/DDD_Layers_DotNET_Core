using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OSR.Infrastructure.Persistance.Sql.Seed;

namespace OSR.MigrateDatabase
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration    = BuildConfigurationRoot();
            var loggerFactory    = BuildLoggerFactory();
            var dbContextFactory = BuildDesignTimeDbContextFactory(configuration, loggerFactory);

            DisplayCurrenEnvironment();

            // create database
            InitializeDatabase(dbContextFactory);

            // seed database
            try
            {
                await SeedData(dbContextFactory);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Database created");

            Console.ReadKey();
        }

        private static void DisplayCurrenEnvironment()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Current Environment :  {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
            Console.ResetColor();
        }

        private static async Task SeedData(DesignTimeDbContextFactory dbContextFactory)
        {

            using (var dbContext = dbContextFactory.CreateDbContext(args: Array.Empty<string>()))
            {
                Seeder.Seed(dbContext);
                await dbContext.SaveChangesAsync();
            }
        }

        private static DesignTimeDbContextFactory BuildDesignTimeDbContextFactory(
            IConfiguration configuration,
            LoggerFactory loggerFactory)
        {
            return new DesignTimeDbContextFactory(configuration, loggerFactory);
        }

        private static IConfigurationRoot BuildConfigurationRoot()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" ) ?? "Production"}.json" , optional: true )
                .Build();
            return configuration;
        }

        private static LoggerFactory BuildLoggerFactory()
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();
            return loggerFactory;
        }

        private static void InitializeDatabase( DesignTimeDbContextFactory contextFactory )
        {
            using( var context = contextFactory.CreateDbContext( args: Array.Empty<string>() ) )
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();  

                //context.Database.Migrate(); // use migration files
            }
        }
    }
}
