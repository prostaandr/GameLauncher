using GameLauncher.Model;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF.ViewModels
{
    public class StorePageViewModel : BaseViewModel
    {
        MainViewModel _main;
        private IApplicationService _applicationService;

        private List<Application> _applications;
        public List<Application> Applications
        {
            get => _applications;
            set
            {
                if (value == _applications) return;
                _applications = value;
                OnPropertyChanged();
            }
        }

        private string _searchBarText;
        public string SearchBarText
        {
            get => _searchBarText;
            set
            {
                if (value == _searchBarText) return;
                _searchBarText = value;
                OnPropertyChanged();
            }
        }

        private List<Genre> _genres;
        public List<Genre> Genres
        {
            get => _genres;
            set
            {
                if (value == _genres) return;
                _genres = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _openApplicationPageCommand;
        public RelayCommand OpenApplicationPageCommand
        {
            get
            {
                return _openApplicationPageCommand ??
                  (_openApplicationPageCommand = new RelayCommand(obj =>
                  {
                      _main.CurrentViewModel = new ApplicationPageViewModel(Convert.ToInt32(obj));
                  }));
            }
        }

        public StorePageViewModel(MainViewModel main)
        {
            _main = main;
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            Applications = await _applicationService.GetApplications();
            Genres = await _applicationService.GetGenres();
        }
    }
}
