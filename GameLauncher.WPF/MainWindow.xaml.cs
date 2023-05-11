using GameLauncher.Data;
using GameLauncher.Data.Interfaces;
using GameLauncher.Data.Repositories;
using GameLauncher.Data.Services;
using GameLauncher.Model;
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

            TestView();
        }

        public async Task TestView()
        {
            var service = App.serviceProvider.GetService<IApplicationService>();

            var application = await service.GetApplication(3);

            gameNameTextBlock.Text = application.Name;
            releaseDateTextBlock.Text = application.ReleaseDate.ToShortDateString().ToString();
            shortDescriptionTextBlock.Text = application.Description;
            posterImage.Source = new BitmapImage(new Uri(application.PosterUrl));
            develoverTextBlock.Text = application.Developer.Name;
            publisherTextBlock.Text = application.Publisher.Name;
            priceTextBlock.Text = application.Price.ToString();
        }
    }
}
