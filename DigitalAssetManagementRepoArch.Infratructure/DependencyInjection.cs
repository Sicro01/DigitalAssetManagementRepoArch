using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalAssetManagementRepoArch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DAMConnection"),
                    b => b.MigrationsAssembly((typeof(ApplicationDbContext).Assembly.FullName))));
            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IPhaseStrategyRepository, PhaseStrategyRepository>();
            services.AddTransient<IPhaseRepository, PhaseRepository>();
            services.AddTransient<IStrategyRepository, StrategyRepository>();

            return services;
        }
    }
}
