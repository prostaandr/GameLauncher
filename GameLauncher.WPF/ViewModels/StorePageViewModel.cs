using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.DTOs;
using GameLauncher.Service.Interfaces;
using GameLauncher.Service.OrderFilter;
using GameLauncher.WPF.Commands;
using GameLauncher.WPF.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace GameLauncher.WPF.ViewModels
{
    public class StorePageViewModel : BaseViewModel
    {
        MainViewModel _main;
        private IApplicationService _applicationService;

        private List<ApplicationDto> _applications;
        public List<ApplicationDto> Applications
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

        private List<string> _sortOptions;
        public List<string> SortOptions
        {
            get => _sortOptions;
            set
            {
                if (value == _sortOptions) return;
                _sortOptions = value;
                OnPropertyChanged();
            }
        }

        private int _selectedSortIndex;
        public int SelectedSortIndex
        {
            get => _selectedSortIndex;
            set
            {
                if (value == _selectedSortIndex) return;
                _selectedSortIndex = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<string, ApplicationFilterOption> _filters;

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

        private List<Feature> _features;
        public List<Feature> Features
        {
            get => _features;
            set
            {
                if (value == _features) return;
                _features = value;
                OnPropertyChanged();
            }
        }

        private List<Language> _languages;
        public List<Language> Languages
        {
            get => _languages;
            set
            {
                if (value == _languages) return;
                _languages = value;
                OnPropertyChanged();
            }
        }

        private int _role;
        public int Role
        {
            get => _role;
            set
            {
                if (value == _role) return;
                _role = value;
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
                      _main.CurrentViewModel = new ApplicationPageViewModel(_main, Convert.ToInt32(obj));
                  }));
            }
        }

        private RelayCommand _openBasketCommand;
        public RelayCommand OpenBasketCommand
        {
            get
            {
                return _openBasketCommand ??
                  (_openBasketCommand = new RelayCommand(obj =>
                  {
                      _main.CurrentViewModel = new BasketViewModel(_main);
                  }));
            }
        }

        private RelayCommand _changeSortOptionCommand;
        public RelayCommand ChangeSortOptionCommand
        {
            get
            {
                return _changeSortOptionCommand ??
                  (_changeSortOptionCommand = new RelayCommand(obj =>
                  {
                      SetApplications();
                  }));
            }
        }

        private RelayCommand _changeFilterOptionCommand;
        public RelayCommand ChangeFilterOptionCommand
        {
            get
            {
                return _changeFilterOptionCommand ??
                  (_changeFilterOptionCommand = new RelayCommand(obj =>
                  {
                      var checkBox = obj as CheckBox;

                      ApplicationFilterOption option = ApplicationFilterOption.ByGenre;
                      if (checkBox.Name == "genreCheckBox") option = ApplicationFilterOption.ByGenre;
                      else if (checkBox.Name == "featureCheckBox") option = ApplicationFilterOption.ByFeature;
                      else if (checkBox.Name == "languageCheckBox") option = ApplicationFilterOption.ByLanguage;
                      else throw new Exception("Неизвестная фильтрация");

                      if (checkBox.IsChecked == true)
                      {
                          _filters.Add(checkBox.Content.ToString(), option);
                      }
                      else if (checkBox.IsChecked == false)
                      {
                          _filters.Remove(checkBox.Content.ToString());
                      }

                      SetApplications();
                  }));
            }
        }

        public string ActualSearch = "";

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return _searchCommand ??
                  (_searchCommand = new RelayCommand(obj =>
                  {
                      ActualSearch = SearchBarText;
                      SetApplications();
                  }));
            }
        }


        private RelayCommand _addGameCommand;
        public RelayCommand AddGameCommand
        {
            get
            {
                return _addGameCommand ??
                  (_addGameCommand = new RelayCommand(obj =>
                  {
                      _main.CurrentViewModel = new SetApplicationViewModel();
                  }));
            }
        }

        private async Task SetApplications()
        {
            Applications = Task.FromResult(await _applicationService.GetApplications(ActualSearch, (ApplicationSortOptions)SelectedSortIndex, _filters)).Result.ToList();
        }



        public StorePageViewModel(MainViewModel main)
        {
            _main = main;
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            Genres = _applicationService.GetGenres().ToList();
            Features = _applicationService.GetFeatures().ToList();
            Languages = _applicationService.GetLanguages().ToList();

            SortOptions = new List<string>
            {
                "По имени",
                "По отзывам",
                "По цене (↑)",
                "По цене (↓)",
                "По дате выхода (↑)",
                "По дате выхода (↓)"
            };

            SelectedSortIndex = 5;

            _filters = new Dictionary<string, ApplicationFilterOption>();

            Role = (int)AccountService.CurrentUser.Role;

            SetApplications();
        }

        private async void InitializeAsync()
        {
           
        }
    }
}
