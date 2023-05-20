using GameLauncher.Data;
using GameLauncher.Data.Interfaces;
using GameLauncher.Data.Repositories;
using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Helpers;
using GameLauncher.WPF.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GameLauncher.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            //var optionsBuilder = new DbContextOptionsBuilder<GameLauncherContext>();
            //var options = optionsBuilder
            //    .UseSqlServer(connectionString)
            //    .Options;
        }

        private void ConfigureServices(ServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<GameLauncherContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Transient);

            services.AddSingleton<Navigator>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddSingleton<LoginWindow>();
            services.AddSingleton<RegistrationWindow>();
            services.AddSingleton<MainWindow>();

            services.AddSingleton<ApplicationPage>();
            services.AddSingleton<LibraryPage>();
            services.AddSingleton<StorePage>();
        }
    }
}
