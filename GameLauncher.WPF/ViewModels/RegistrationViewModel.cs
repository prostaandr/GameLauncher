using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
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
    public class RegistrationViewModel : BaseViewModel
    {
        private IAccountService _accountService;

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                if (value == _user) return;
                _user = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CountryViewModel> _countries;
        public ObservableCollection<CountryViewModel> Countries
        {
            get => _countries;
            set
            {
                if (value == _countries) return;
                _countries = value;
                OnPropertyChanged();
            }
        }

        private string _repeatePassword;
        public string RepeatePassword
        {
            get => _repeatePassword;
            set
            {
                if (value == _repeatePassword) return;
                _repeatePassword = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addUserCommand;
        public RelayCommand AddUserCommand
        {
            get
            {
                return _addUserCommand ??
                  (_addUserCommand = new RelayCommand(obj =>
                  {
                      var country = obj as CountryViewModel;
                      User.CountryId = Convert.ToInt32(country.Country.Id);
                      AddUserAsync();
                      MessageBox.Show("Регистрация прошла успешно");
                  }));
            }
        }

        private async void AddUserAsync()
        {
            await _accountService.Registration(User);
        }

        public RegistrationViewModel()
        {
            _accountService = App.serviceProvider.GetService<IAccountService>();

            User = new User();

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            Countries = new ObservableCollection<CountryViewModel>();
            var countries = await _accountService.GetAllCountries();
            for (int i = 0; i < countries.Count; i++)
            {
                Countries.Add(new CountryViewModel() { Country = countries[i] });
            }
        }
    }
}
