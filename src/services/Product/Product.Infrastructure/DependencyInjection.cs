using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Repository.Abstraction;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Persistence.Repository.Command;
using Product.Infrastructure.Persistence.Repository.Query;

namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProductInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
            
            services.AddTransient<IProductCommandRepository, ProductCommandRepository>();
            services.AddTransient<IProductQueryRepository, ProductQueryRepository>();

            return services;
        }
    }
}