using GameLauncher.Model;
using GameLauncher.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationDto _application;
        public ApplicationDto Application
        {
            get => _application;
            set
            {
                if (value == _application) return;
                _application = value;
                OnPropertyChanged();
            }
        }
    }
}
