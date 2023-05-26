﻿using GameLauncher.Model;
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
                      else if (checkBox.Name == "featureCheckBox") return;
                      else if (checkBox.Name == "languageCheckBox") return;
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

        private async Task SetApplications()
        {
            Applications = Task.FromResult(await _applicationService.GetApplications((ApplicationSortOptions)SelectedSortIndex, _filters)).Result.ToList();
        }

        public StorePageViewModel(MainViewModel main)
        {
            _main = main;
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            Genres = _applicationService.GetGenres().ToList();

            SortOptions = new List<string>
            {
                "По имени",
                "По отзывам",
                "По цене (↑)",
                "По цене (↓)",
                "По дате выхода (↑)",
                "По дате выхода (↓)"
            };

            SelectedSortIndex = 4;

            _filters = new Dictionary<string, ApplicationFilterOption>();

            SetApplications();
        }

        private async void InitializeAsync()
        {
           
        }
    }
}
