using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Server.Database
{
    public static class SimpleSelfMigrator
    {
        public static void Migrate(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();

            ctx.Database.Migrate();
        }
    }
}
