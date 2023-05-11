using GameLauncher.Data;
using GameLauncher.Data.Interfaces;
using GameLauncher.Data.Repositories;
using GameLauncher.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLauncher.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ContextFactory contextFactory = new ContextFactory();
            //GameLauncherContext db = contextFactory.CreateDbContext(Environment.GetCommandLineArgs());
            //var service = new ApplicationService(new ApplicationRepository(db));

            var service = App.serviceProvider.GetService<IApplicationService>();

            var applications = service.GetApplications().ToList();

            idTextBox.Text = applications[0].Id.ToString();
            nameTextBox.Text = applications[0].Name;
            descriptionTextBox.Text = applications[0].Description;
            priceTextBox.Text = applications[0].Price.ToString();
            releaseDateTextBox.Text = applications[0].ReleaseDate.ToString();
            typeTextBox.Text = applications[0].ApplicationType.ToString();
        }
    }
}
