using System;
using System.Windows.Forms;
using Invoice.App.Forms;
using Invoice.Application;
using Invoice.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Invoice.App
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;
                    services.AddInvoiceInfrastructure(config);
                    services.AddInvoiceApplication(config);

                    services.AddSingleton<MainPage>();
                    services.AddTransient<MyStore>();
                    services.AddLogging(configure => configure.AddConsole());


                    
                });

            var host = hostBuilder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
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