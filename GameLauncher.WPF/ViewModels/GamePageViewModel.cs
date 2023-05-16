using GameLauncher.Model;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace GameLauncher.WPF.ViewModels
{
    public class GamePageViewModel : BaseViewModel
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

        private string _reviewsPersent;
        public string ReviewsPersent
        {
            get => _reviewsPersent;
            set
            {
                if (value == _reviewsPersent) return;
                _reviewsPersent = value;
                OnPropertyChanged();
            }
        }

        private string _genres;
        public string Genres
        {
            get => _genres;
            set
            {
                if (value == _genres) return;
                _genres = value;
                OnPropertyChanged();
            }
        }

        private string _features;
        public string Features
        {
            get => _features;
            set
            {
                if (value == _features) return;
                _features = value;
                OnPropertyChanged();
            }
        }

        private string _languages;
        public string Languages
        {
            get => _languages;
            set
            {
                if (value == _languages) return;
                _languages = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SystemRequirementsViewModel> _minSystemRequirements;
        public ObservableCollection<SystemRequirementsViewModel> MinSystemRequirements
        {
            get => _minSystemRequirements;
            set
            {
                if (Equals(value, _minSystemRequirements)) return;
                _minSystemRequirements = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SystemRequirementsViewModel> _recSystemRequirements;
        public ObservableCollection<SystemRequirementsViewModel> RecSystemRequirements
        {
            get => _recSystemRequirements;
            set
            {
                if (Equals(value, _recSystemRequirements)) return;
                _recSystemRequirements = value;
                OnPropertyChanged();
            }
        }

        private string _mainImageUrl;
        public string MainImageUrl
        {
            get => _mainImageUrl;
            set
            {
                if (value == _mainImageUrl) return;
                _mainImageUrl = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _changeMainImageCommand;
        public RelayCommand ChangeMainImageCommand
        {
            get
            {
                return _changeMainImageCommand ??
                  (_changeMainImageCommand = new RelayCommand(obj =>
                  {
                      var index = Convert.ToInt32(obj);
                      if (index >= 0)
                      MainImageUrl = Application.Medias[index].Url;
                  }));
            }
        }

        public GamePageViewModel()
        {
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            Application = await _applicationService.GetApplication(3);

            ReviewsPersent = (await _applicationService.GetReviewsPersent(3)).ToString();

            MainImageUrl = Application.Medias[0].Url;

            Genres = String.Join(", ", Application.Genres.Select(g => g.Name));
            Features = String.Join(", ", Application.Features.Select(f => f.Name));
            Languages = String.Join(", ", Application.Languages.Select(l => l.Name));

            RecSystemRequirements = FillSystemRequirements(Application.RecommendedSystemRequirements);
            MinSystemRequirements = FillSystemRequirements(Application.MinimumSystemRequirements);
        }

        private ObservableCollection<SystemRequirementsViewModel> FillSystemRequirements(SystemRequirements systemRequirements)
        {
            if (systemRequirements == null) return null;

            ObservableCollection<SystemRequirementsViewModel> list = new ObservableCollection<SystemRequirementsViewModel>();

            if (systemRequirements.OS != null && systemRequirements.OS != "")
                list.Add(new SystemRequirementsViewModel { Title = "ОС: ", Value = systemRequirements.OS });

            if (systemRequirements.Processor != null && systemRequirements.Processor != "")
                list.Add(new SystemRequirementsViewModel { Title = "Процессор: ", Value = systemRequirements.Processor });

            if (systemRequirements.Memory != null && systemRequirements.Memory != "")
                list.Add(new SystemRequirementsViewModel { Title = "Память: ", Value = systemRequirements.Memory });

            if (systemRequirements.Graphics != null && systemRequirements.Graphics != "")
                list.Add(new SystemRequirementsViewModel { Title = "Графика: ", Value = systemRequirements.Graphics });

            if (systemRequirements.DirectX != null && systemRequirements.DirectX != "")
                list.Add(new SystemRequirementsViewModel { Title = "DirectX: ", Value = systemRequirements.DirectX });

            if (systemRequirements.Network != null && systemRequirements.Network != "")
                list.Add(new SystemRequirementsViewModel { Title = "Сеть: ", Value = systemRequirements.Network });

            if (systemRequirements.Storage != null && systemRequirements.Storage != "")
                list.Add(new SystemRequirementsViewModel { Title = "Место на диске: ", Value = systemRequirements.Storage });

            return list;
        }
    }
}
    