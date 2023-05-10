using GameLauncher.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF
{
    public class ContextFactory : IDesignTimeDbContextFactory<GameLauncherContext>
    {
        public GameLauncherContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var option = new DbContextOptionsBuilder<GameLauncherContext>()
            .UseSqlServer(connectionString).Options;
            return new GameLauncherContext(option);
        }
    }
}
