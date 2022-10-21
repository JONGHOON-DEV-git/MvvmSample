using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MVVM_Example_dotnet6.viewmodels;

namespace MVVM_Example_dotnet6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            
        }

        public IServiceProvider Services { get; }

        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient(typeof(MainViewModel));
            return services.BuildServiceProvider();
        }
    }
}
