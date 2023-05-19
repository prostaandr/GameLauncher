using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IAccountService _accountService;

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

        public MainViewModel()
        {
            _accountService = App.serviceProvider.GetService<IAccountService>();
            
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            if (AccountService.CurrentUser == null) AccountService.CurrentUser = await _accountService.GetUser(1);
            CurrentUser = AccountService.CurrentUser;
        }
    }
}
