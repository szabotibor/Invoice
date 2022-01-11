using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Invoice.Application.Messaging.Queries;
using MediatR;
using Invoice.Application.Services;

namespace Invoice.Application
{
    public static class DepenedencyInjection
    {
        public static IServiceCollection AddInvoiceApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
