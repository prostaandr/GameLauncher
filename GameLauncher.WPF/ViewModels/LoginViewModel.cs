﻿using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using GameLauncher.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameLauncher.WPF.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private IAccountService _accountService;

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                  (_loginCommand = new RelayCommand(obj =>
                  {
                      LoginAsync();

                      var appPage = new ApplicationPage();
                      appPage.Show();
                  }));
            }
        }

        private async void LoginAsync()
        {
            var loginUser = await _accountService.Login(Login, Password);
            AccountService.CurrentUser = loginUser;

        }

        public LoginViewModel()
        {
            _accountService = App.serviceProvider.GetService<IAccountService>();
        }
    }
}
