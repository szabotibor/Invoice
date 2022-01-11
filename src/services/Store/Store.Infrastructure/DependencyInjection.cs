using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Repository;
using Store.Application.Repository.Abstraction;
using Store.Infrastructure.Persistence;
using Store.Infrastructure.Persistence.Repository.Command;
using Store.Infrastructure.Persistence.Repository.Query;

namespace Store.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddStoreInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IStoreCommandRepository, StoreCommandRepository>();
            services.AddTransient<IStoreQueryRepository, StoreQueryRepository>();

            return services;
        }
    }
}