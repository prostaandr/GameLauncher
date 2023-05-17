using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        public Country _country;
        public Country Country
        {
            get => _country;
            set
            {
                if (value == _country) return;
                _country = value;
                OnPropertyChanged();
            }
        }
    }
}
