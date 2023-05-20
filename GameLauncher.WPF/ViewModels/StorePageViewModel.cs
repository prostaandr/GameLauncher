using GameLauncher.Model;
using GameLauncher.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF.ViewModels
{
    public class StorePageViewModel : BaseViewModel
    {
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

        public StorePageViewModel()
        {
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
