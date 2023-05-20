using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using GameLauncher.WPF.Helpers;
using GameLauncher.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameLauncher.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (value == _currentViewModel) return;
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (value == _currentUser) return;
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _openStorePageCommand;
        public RelayCommand OpenStorePageCommand
        {
            get
            {
                return _openStorePageCommand ??
                  (_openStorePageCommand = new RelayCommand(obj =>
                  {
                      CurrentViewModel = new StorePageViewModel();
                  }));
            }
        }

        private RelayCommand _openLibraryPageCommand;
        public RelayCommand OpenLibraryPageCommand
        {
            get
            {
                return _openLibraryPageCommand ??
                  (_openLibraryPageCommand = new RelayCommand(obj =>
                  {
                      CurrentViewModel = new LibraryViewModel(this);
                  }));
            }
        }

        private Navigator _navigator = new Navigator();

        public MainViewModel()
        {
            _accountService = App.serviceProvider.GetService<IAccountService>();
            CurrentViewModel = new StorePageViewModel();

            InitializeAsync();

            _navigator.ChangeViewModel += OnChangeViewModel;
        }

        private async void InitializeAsync()
        {
            if (AccountService.CurrentUser == null) AccountService.CurrentUser = await _accountService.GetUser(1);
            CurrentUser = AccountService.CurrentUser;
        }

        private void OnChangeViewModel(object sender, EventArgs e)
        {
            var n = sender as Navigator;
            CurrentViewModel = n.CurrentViewModel;
        }
    }
}
