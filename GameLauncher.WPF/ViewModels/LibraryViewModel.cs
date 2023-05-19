using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameLauncher.WPF.ViewModels
{
    public class LibraryViewModel : BaseViewModel
    {
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

        private Application _selectedApplication;
        public Application SelectedApplication
        {
            get => _selectedApplication;
            set
            {
                if (value == _selectedApplication) return;
                _selectedApplication = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _changeSelectedApplicationCommand;
        public RelayCommand ChangeSelectedApplicationCommand
        {
            get
            {
                return _changeSelectedApplicationCommand ??
                  (_changeSelectedApplicationCommand = new RelayCommand(obj =>
                  {
                      var app = obj as Application;
                      SelectedApplication = app;
                  }));
            }
        }

        private RelayCommand _openApplicationPageCommand;
        public RelayCommand OpenApplicationPageCommand
        {
            get
            {
                return _openApplicationPageCommand ??
                  (_changeSelectedApplicationCommand = new RelayCommand(obj =>
                  {
                      
                  }));
            }
        }

        public LibraryViewModel()
        {
            Applications = AccountService.CurrentUser.AvailableApplications;;
        }

        private async void InitializeAsync()
        {

        }
    }
}
