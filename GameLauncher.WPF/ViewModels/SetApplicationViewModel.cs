using GameLauncher.Model;
using GameLauncher.Service.DTOs;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GameLauncher.WPF.ViewModels
{
    public class SetApplicationViewModel : BaseViewModel
    {
        private IApplicationService _applicationService;

        private Application _application;
        public Application Application
        {
            get => _application;
            set
            {
                if (value == _application) return;
                _application = value;
                OnPropertyChanged();
            }
        }

        private List<Developer> _developers;
        public List<Developer> Developers
        {
            get => _developers;
            set
            {
                if (value == _developers) return;
                _developers = value;
                OnPropertyChanged();
            }
        }

        private int _selectedDeveloper;
        public int SelectedDeveloper
        {
            get => _selectedDeveloper;
            set
            {
                if (value == _selectedDeveloper) return;
                _selectedDeveloper = value;
                OnPropertyChanged();
            }
        }

        private List<Publisher> _publishers;
        public List<Publisher> Publishers
        {
            get => _publishers;
            set
            {
                if (value == _publishers) return;
                _publishers = value;
                OnPropertyChanged();
            }
        }

        private int _selectedPublisher;
        public int SelectedPublisher
        {
            get => _selectedPublisher;
            set
            {
                if (value == _selectedPublisher) return;
                _selectedPublisher = value;
                OnPropertyChanged();
            }
        }

        private List<Genre> _genre;
        public List<Genre> Genres
        {
            get => _genre;
            set
            {
                if (value == _genre) return;
                _genre = value;
                OnPropertyChanged();
            }
        }

        private int _selectedGenre;
        public int SelectedGenre
        {
            get => _selectedGenre;
            set
            {
                if (value == _selectedGenre) return;
                _selectedGenre = value;
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

        private int _selectedFeature;
        public int SelectedFeature
        {
            get => _selectedFeature;
            set
            {
                if (value == _selectedFeature) return;
                _selectedFeature = value;
                OnPropertyChanged();
            }
        }

        private List<Language> languages;
        public List<Language> Languages
        {
            get => languages;
            set
            {
                if (value == languages) return;
                languages = value;
                OnPropertyChanged();
            }
        }

        private int _selectedLanguage;
        public int SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (value == _selectedLanguage) return;
                _selectedLanguage = value;
                OnPropertyChanged();
            }
        }

        private bool _isNew;
        public bool IsNew
        {
            get => _isNew;
            set
            {
                if (value == _isNew) return;
                _isNew = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addGenreCommand;
        public RelayCommand AddGenreCommand
        {
            get
            {
                return _addGenreCommand ??
                  (_addGenreCommand = new RelayCommand(obj =>
                  {
                      lock (_itemsLock)
                      {
                          Application.Genres.Add(Genres[SelectedGenre]);
                      }
                  }));
            }
        }

        private RelayCommand _addFeatureCommand;
        public RelayCommand AddFeatureCommand
        {
            get
            {
                return _addFeatureCommand ??
                  (_addFeatureCommand = new RelayCommand(obj =>
                  {
                      lock (_itemsLock)
                      {
                          Application.Features.Add(Features[SelectedFeature]);
                      }
                  }));
            }
        }

        private RelayCommand _addLanguageCommand;
        public RelayCommand AddLanguageCommand
        {
            get
            {
                return _addLanguageCommand ??
                  (_addLanguageCommand = new RelayCommand(obj =>
                  {
                      var listBox = obj as ListBox;
                      lock (_itemsLock)
                      {
                          Application.Languages.Add(Languages[SelectedLanguage]);
                      }
                  }));
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                  (_saveCommand = new RelayCommand(obj =>
                  {
                      if (IsNew)
                      {
                          Application.ReleaseDate = DateTime.Now;
                          Application.DeveloperId = Developers[SelectedDeveloper].Id;
                          Application.PublisherId = Publishers[SelectedPublisher].Id;
                      }
                      SaveAsync();

                      System.Windows.MessageBox.Show("Игра сохранена");
                  }));
            }
        }

        private async void SaveAsync()
        {
            await _applicationService.SetApplication(Application, IsNew);
        }

        public SetApplicationViewModel(int appId)
        {
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            Developers = _applicationService.GetDevelopers().ToList();
            Publishers = _applicationService.GetPublishers().ToList();

            IsNew = false;

            InitializeAsync(appId);
        }

        public SetApplicationViewModel()
        {
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            Developers = _applicationService.GetDevelopers().ToList();
            Publishers = _applicationService.GetPublishers().ToList();

            Application = new Application();
            Application.Medias = new List<Media>();
            Application.MinimumSystemRequirements = new SystemRequirements();
            Application.RecommendedSystemRequirements = new SystemRequirements();

            IsNew = true;

            InitializeAsync();
        }

        Object _itemsLock;

        private async void InitializeAsync(int appId)
        {
            Application = await _applicationService.GetApplicationForSet(appId);

            _itemsLock = new object();

            Genres = await _applicationService.GetGenres().ToListAsync();
            Features = await _applicationService.GetFeatures().ToListAsync();
            Languages = await _applicationService.GetLanguages().ToListAsync();

            SelectedGenre = -1;
            SelectedFeature = -1;
            SelectedLanguage = -1;

            SelectedDeveloper = FindDeveloper();
            SelectedPublisher = FindPublisher();

            BindingOperations.EnableCollectionSynchronization(Application.Genres, _itemsLock);
            BindingOperations.EnableCollectionSynchronization(Application.Features, _itemsLock);
            BindingOperations.EnableCollectionSynchronization(Application.Languages, _itemsLock);
        }

        private async void InitializeAsync()
        {
            _itemsLock = new object();

            Genres = await _applicationService.GetGenres().ToListAsync();
            Features = await _applicationService.GetFeatures().ToListAsync();
            Languages = await _applicationService.GetLanguages().ToListAsync();

            SelectedGenre = -1;
            SelectedFeature = -1;
            SelectedLanguage = -1;

            SelectedDeveloper = -1;
            SelectedPublisher = -1;

            BindingOperations.EnableCollectionSynchronization(Application.Genres, _itemsLock);
            BindingOperations.EnableCollectionSynchronization(Application.Features, _itemsLock);
            BindingOperations.EnableCollectionSynchronization(Application.Languages, _itemsLock);
        }

        private int FindDeveloper()
        {
            int index = -1;

            for (int i = 0; i < Developers.Count; i++)
            {
                if (Developers[i].Name == Application.Developer.Name)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private int FindPublisher()
        {
            int index = -1;

            for (int i = 0; i < Developers.Count; i++)
            {
                if (Developers[i].Name == Application.Publisher.Name)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
