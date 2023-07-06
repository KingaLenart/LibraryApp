using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Core.SQL.DI
{
    public static class LibraryDatabaseDI
    {
        public static void AddLibraryDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryDatabaseContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Sql"),
                providerOptions =>
            {
                providerOptions.MigrationsAssembly("LibraryApp.Core.SQL");
                providerOptions.CommandTimeout(600);
                providerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            }), ServiceLifetime.Scoped);
        }
    }
}
