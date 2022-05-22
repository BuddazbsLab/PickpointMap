using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickpointMap_Backend.Interface;

namespace PickpointMap_Backend.Persistence.APT
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
             services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<PickpointMapDbContext>(options =>
            {
                options.UseSqlite("Data Source=PickpointMap.APT.db");
            });
            services.AddScoped<IPickpointMapDbContext>(provider =>
                 provider.GetService<PickpointMapDbContext>());
            return services;
        }
    }
}
