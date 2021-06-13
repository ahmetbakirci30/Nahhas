using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nahhas.Library.Managers.Files;
using Nahhas.Library.Managers.Files.Interfaces;
using Nahhas.Library.Repositories;
using Nahhas.Library.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.Library.Extensions.Startup
{
    public static class StartupExtensions
    {
        public static void AddRequiredServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NahhasDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IFileManager), typeof(FileManager));
        }

        public static async Task SeedDataAsync(this IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<NahhasDbContext>();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();
            }
        }
    }
}