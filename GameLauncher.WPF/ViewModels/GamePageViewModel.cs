using GameLauncher.Model;
using GameLauncher.Service.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

        private ObservableCollection<SystemRequirementsBlock> _recSystemRequirements;
        public ObservableCollection<SystemRequirementsBlock> RecSystemRequirements
        {
            get => _recSystemRequirements;
            set
            {
                if (Equals(value, _recSystemRequirements)) return;
                _recSystemRequirements = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SystemRequirementsBlock> _minSystemRequirements;
        public ObservableCollection<SystemRequirementsBlock> MinSystemRequirements
        {
            get => _recSystemRequirements;
            set
            {
                if (Equals(value, _recSystemRequirements)) return;
                _recSystemRequirements = value;
                OnPropertyChanged();
            }
        }

        public GamePageViewModel()
        {
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            Application = await _applicationService.GetApplication(3);

            ReviewsPersent = (await _applicationService.GetReviewsPersent(3)).ToString();

            Genres = String.Join(", ", Application.Genres.Select(g => g.Name));
            Features = String.Join(", ", Application.Features.Select(f => f.Name));
            Languages = String.Join(", ", Application.Languages.Select(l => l.Name));

            RecSystemRequirements = FillSystemRequirements(Application.RecommendedSystemRequirements);
            MinSystemRequirements = FillSystemRequirements(Application.MinimumSystemRequirements);
        }

        private ObservableCollection<SystemRequirementsBlock> FillSystemRequirements(SystemRequirements systemRequirements)
        {
            if (systemRequirements == null) return null;

            ObservableCollection<SystemRequirementsBlock> list = new ObservableCollection<SystemRequirementsBlock>();

            if (systemRequirements.OS != null && systemRequirements.OS != "")
                list.Add(new SystemRequirementsBlock { Title = "ОС: ", Value = systemRequirements.OS });

            if (systemRequirements.Processor != null && systemRequirements.Processor != "")
                list.Add(new SystemRequirementsBlock { Title = "Процессор: ", Value = systemRequirements.Processor });

            if (systemRequirements.Memory != null && systemRequirements.Memory != "")
                list.Add(new SystemRequirementsBlock { Title = "Память: ", Value = systemRequirements.Memory });

            if (systemRequirements.Graphics != null && systemRequirements.Graphics != "")
                list.Add(new SystemRequirementsBlock { Title = "Графика: ", Value = systemRequirements.Graphics });

            if (systemRequirements.DirectX != null && systemRequirements.DirectX != "")
                list.Add(new SystemRequirementsBlock { Title = "DirectX: ", Value = systemRequirements.DirectX });

            if (systemRequirements.Network != null && systemRequirements.Network != "")
                list.Add(new SystemRequirementsBlock { Title = "Сеть: ", Value = systemRequirements.Network });

            if (systemRequirements.Storage != null && systemRequirements.Storage != "")
                list.Add(new SystemRequirementsBlock { Title = "Место на диске: ", Value = systemRequirements.Storage });

            return list;
        }

        public class SystemRequirementsBlock : BaseViewModel
        {
            public string Title { get; set; }
            public string Value { get; set; }

        }
    }
}
    