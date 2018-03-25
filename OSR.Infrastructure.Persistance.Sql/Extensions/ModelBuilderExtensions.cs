using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OSR.Infrastructure.Persistance.Sql.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention( this ModelBuilder modelBuilder )
        {
            foreach( IMutableEntityType entity in modelBuilder.Model.GetEntityTypes() )
            {
                var tableName = entity.DisplayName();

                entity.Relational().TableName = tableName;
            }
        }
    }
}
