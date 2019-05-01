using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Windows;

namespace BasicWpf01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .Build();
            host.Services.UseNLog();
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static IConfiguration Configuration { get; set; }

        private void ConfigureServices(IServiceCollection services)
        {
            var serviceDescriptor = services.First(x => x.ServiceType == typeof(IConfiguration));
            Configuration = serviceDescriptor.ImplementationInstance as IConfiguration;
            // We can not use IConfiguration

            services.AddTransient(typeof(MainWindow));
        }
    }
}