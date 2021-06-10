using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nahhas.Shared.Managers.Files;
using Nahhas.Shared.Managers.Files.Interfaces;
using Nahhas.Shared.Repositories.Base;
using Nahhas.Shared.Repositories.Interfaces;
using Nahhas.Shared.Services.Base;
using Nahhas.Shared.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.Shared.Helpers.Extensions.Startup
{
    public static class ServicesExtensions
    {
        public static void AddRequiredServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NahhasDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
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