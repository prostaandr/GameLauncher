using GameLauncher.Data;
using GameLauncher.Data.Interfaces;
using GameLauncher.Data.Repositories;
using GameLauncher.Model;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.ViewModels;
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

// TODO: Нужно убрать эти блядские списки с кнопок и системных требований
namespace GameLauncher.WPF.Views
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Window
    {
        public GamePage()
        {
            InitializeComponent();

            DataContext = new GamePageViewModel();
        }

        //private void mediaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    mediaImage.Source = new BitmapImage(new Uri(Medias[mediaListBox.SelectedIndex].Url));
        //}
    }
}
