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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLauncher.WPF.Views
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Window
    {
        IApplicationService service;
        Model.Application application;

        public GamePage()
        {
            InitializeComponent();

            TestView();
        }

        public async Task TestView()
        {
            service = App.serviceProvider.GetService<IApplicationService>();

            application = await service.GetApplication(1);

            for (int i = 0; i < application.Medias.Count; i++)
            {
                mediaListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(application.Medias[i].Url)), Stretch = Stretch.Uniform, StretchDirection = StretchDirection.DownOnly, Height = 80});
            }
            mediaListBox.SelectedIndex = 0;

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

        private void mediaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mediaImage.Source = new BitmapImage(new Uri(application.Medias[mediaListBox.SelectedIndex].Url));
        }
    }
}
