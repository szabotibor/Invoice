using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructure.Persistence;
using Product.Infrastructure.Persistence;

namespace Order.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOrderInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

         

            return services;
        }
    }
}