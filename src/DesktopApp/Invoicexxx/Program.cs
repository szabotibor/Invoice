using System;
using Invoice.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Invoice.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Invoice
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, builderBuilder) =>
                {
                    builderBuilder
                        .SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    services.AddSingleton<MainPage>();
                    services.AddLogging(configure => configure.AddConsole());

                    services.AddTransient<MyStore>();
                    
                    services.AddInvoiceApplication(configuration);
                    services.AddInvoiceInfrastructure(configuration);
                });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    //Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                    var mainForm = services.GetRequiredService<MainPage>();
                    System.Windows.Forms.Application.Run(mainForm);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Occured ({ex.Message})");
                }
            }
        }
    }
}
