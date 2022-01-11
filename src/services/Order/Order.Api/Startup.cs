using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Order.Application;
using Order.Infrastructure;

namespace Order.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = Environment.ApplicationName, Version = "v1" });
                options.SupportNonNullableReferenceTypes();
            });

            services.AddFluentValidationRulesToSwagger();

            services.AddOrderInfrastructure(Configuration);
            services.AddOrderApplication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(options =>
            {
                options.RouteTemplate = ".less-known/api-docs/{documentName}.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/.less-known/api-docs/v1.json", "v1");
                options.RoutePrefix = ".less-known/api-docs/ui";
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}