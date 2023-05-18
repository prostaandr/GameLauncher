using GameLauncher.Model;
using GameLauncher.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (value == _currentUser) return;
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CurrentUser = AccountService.CurrentUser;
            if (CurrentUser == null) CurrentUser = new User() { Nickname = "test", IconUrl = "https://avatars.akamai.steamstatic.com/1aa3ba8fc495dc04406e08791ae031eca01ca0b8_full.jpg" };
        }
    }
}
