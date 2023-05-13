using GameLauncher.Data;
using GameLauncher.Data.Interfaces;
using GameLauncher.Data.Repositories;
using GameLauncher.Model;
using GameLauncher.Service.Interfaces;
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

            var application = await service.GetApplication(1);

            gameNameTextBlock.Text = application.Name;
            releaseDateTextBlock.Text = application.ReleaseDate.ToShortDateString().ToString();
            shortDescriptionTextBlock.Text = application.Description;
            posterImage.Source = new BitmapImage(new Uri(application.PosterUrl));
            develoverTextBlock.Text = application.Developer.Name;
            publisherTextBlock.Text = application.Publisher.Name;
            priceTextBlock.Text = application.Price.ToString();

            genresTextBlock.Text = String.Join(", ", application.Genres.Select(a => a.Name));
            featuresTextBlock.Text = String.Join(", ", application.Features.Select(a => a.Name));
            languagesTextBlock.Text = String.Join(", ", application.Languages.Select(a => a.Name));

            SetElementToListBox(minSystemRequirementsListBox, "ОС: ", application.MinimumSystemRequirements.OS);
            SetElementToListBox(minSystemRequirementsListBox, "Процессор: ", application.MinimumSystemRequirements.Processor);
            SetElementToListBox(minSystemRequirementsListBox, "Память: ", application.MinimumSystemRequirements.Memory);
            SetElementToListBox(minSystemRequirementsListBox, "Графика: ", application.MinimumSystemRequirements.Graphics);
            SetElementToListBox(minSystemRequirementsListBox, "DirectX: ", application.MinimumSystemRequirements.DirectX);
            SetElementToListBox(minSystemRequirementsListBox, "Сеть: ", application.MinimumSystemRequirements.Network);
            SetElementToListBox(minSystemRequirementsListBox, "Место на диске: ", application.MinimumSystemRequirements.Storage);

            SetElementToListBox(recSystemRequirementsListBox, "ОС: ", application.RecommendedSystemRequirements.OS);
            SetElementToListBox(recSystemRequirementsListBox, "Процессор: ", application.RecommendedSystemRequirements.Processor);
            SetElementToListBox(recSystemRequirementsListBox, "Память: ", application.RecommendedSystemRequirements.Memory);
            SetElementToListBox(recSystemRequirementsListBox, "Графика: ", application.RecommendedSystemRequirements.Graphics);
            SetElementToListBox(recSystemRequirementsListBox, "DirectX: ", application.RecommendedSystemRequirements.DirectX);
            SetElementToListBox(recSystemRequirementsListBox, "Сеть: ", application.RecommendedSystemRequirements.Network);
            SetElementToListBox(recSystemRequirementsListBox, "Место на диске: ", application.RecommendedSystemRequirements.Storage);
        }

        public void SetElementToListBox(ListBox listBox, string title, string value)
        {
            if (value != null && value != "")
            {
                listBox.Items.Add(title + value);
            }
        }
    }
}
