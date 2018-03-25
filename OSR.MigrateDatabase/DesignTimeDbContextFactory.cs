using OSR.Infrastructure.Persistance.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OSR.MigrateDatabase
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OSRDbContext>
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public DesignTimeDbContextFactory(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public OSRDbContext CreateDbContext( string[] args )
        {
            var builder = new DbContextOptionsBuilder<OSRDbContext>();

            var connectionString = _configuration.GetConnectionString( "OSRConnection" );

            builder.UseSqlServer( connectionString );
            builder.UseLoggerFactory(_loggerFactory);

            return new OSRDbContext( builder.Options , null);
        }
    }
}
