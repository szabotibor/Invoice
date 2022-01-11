using Invoice.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Invoice.Application.Clients;
using Invoice.Infrastructure.Clients;

namespace Invoice.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInvoiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<StoreApiOptions>(configuration.GetSection("Store"));
            services.Configure<ProductApiOptions>(configuration.GetSection("Product"));

            services.AddTransient<IStoreClient, StoreClient>();
            services.AddTransient<IProductClient, ProductClient>();
            
            return services;
        }
    }
}
