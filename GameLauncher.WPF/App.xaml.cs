﻿using GameLauncher.Data;
using GameLauncher.Data.Interfaces;
using GameLauncher.Data.Repositories;
using GameLauncher.Data.Services;
using GameLauncher.Model;
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
            });

            services.AddScoped<IApplicationRepository, ApplicationRepository>();

            services.AddTransient<IApplicationService, ApplicationService>();

            services.AddSingleton<MainWindow>();
        }
    }
}
