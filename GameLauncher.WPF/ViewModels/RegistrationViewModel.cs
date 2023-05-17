using GameLauncher.Model;
using GameLauncher.Model.Logic;
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


        private string _loginErrors;
        public string LoginErrors
        {
            get => _loginErrors;
            set
            {
                if (value == _loginErrors) return;
                _loginErrors = value;
                OnPropertyChanged();
            }
        }

        private string _emailErrors;
        public string EmailErrors
        {
            get => _emailErrors;
            set
            {
                if (value == _emailErrors) return;
                _emailErrors = value;
                OnPropertyChanged();
            }
        }

        private string _passwordErrors;
        public string PasswordErrors
        {
            get => _passwordErrors;
            set
            {
                if (value == _passwordErrors) return;
                _passwordErrors = value;
                OnPropertyChanged();
            }
        }

        private string _nickName;
        public string NickNameErrors
        {
            get => _nickName;
            set
            {
                if (value == _nickName) return;
                _nickName = value;
                OnPropertyChanged();
            }
        }

        private string _countryErrors;
        public string CountryErrors
        {
            get => _countryErrors;
            set
            {
                if (value == _countryErrors) return;
                _countryErrors = value;
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
                      if (country == null) country = new CountryViewModel() { Country = new Country() };

                      LoginErrors = String.Join("\n", User.Login.Rules().NotEmpty().MinCharacters(5).MaxCharacters(30).Validate());
                      EmailErrors = String.Join("\n", User.Email.Rules().NotEmpty().Validate());
                      PasswordErrors = String.Join("\n", User.Password.Rules().NotEmpty().MinCharacters(8).Compliance(RepeatePassword, "Подтверждение пароля").Validate());
                      NickNameErrors = String.Join("\n", User.Nickname.Rules().NotEmpty().MinCharacters(5).MaxCharacters(20).Validate());
                      CountryErrors = String.Join("\n", country.Country.Name.Rules().NotEmpty().Validate());

                      if (String.IsNullOrEmpty(LoginErrors) && String.IsNullOrEmpty(EmailErrors) && String.IsNullOrEmpty(PasswordErrors) &&
                      String.IsNullOrEmpty(NickNameErrors) && String.IsNullOrEmpty(CountryErrors))
                      {
                          User.CountryId = Convert.ToInt32(country.Country.Id);
                          AddUserAsync();
                          MessageBox.Show("Регистрация прошла успешно");
                      }
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
