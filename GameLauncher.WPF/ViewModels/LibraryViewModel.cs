using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using GameLauncher.WPF.Helpers;
using GameLauncher.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GameLauncher.WPF.ViewModels
{
    public class LibraryViewModel : BaseViewModel
    {
        private MainViewModel _main;
        private IAccountService _accountService;

        private List<Model.Application> _applications;
        public List<Model.Application> Applications
        {
            get => _applications;
            set
            {
                if (value == _applications) return;
                _applications = value;
                OnPropertyChanged();
            }
        }

        private Model.Application _selectedApplication;
        public Model.Application SelectedApplication
        {
            get => _selectedApplication;
            set
            {
                if (value == _selectedApplication) return;
                _selectedApplication = value;
                OnPropertyChanged();
            }
        }

        private bool _isNewReview;
        public bool IsNewReview
        {
            get => _isNewReview;
            set
            {
                if (value == _isNewReview) return;
                _isNewReview = value;
                OnPropertyChanged();
            }
        }


        private RelayCommand _changeSelectedApplicationCommand;
        public RelayCommand ChangeSelectedApplicationCommand
        {
            get
            {
                return _changeSelectedApplicationCommand ??
                  (_changeSelectedApplicationCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          int index = Convert.ToInt32(obj);
                          if (index != -1)
                          {
                              SelectedApplication = Applications[index];


                              Review = _accountService.GetReview(SelectedApplication.Id, AccountService.CurrentUser.Id);

                              if (Review == null)
                              {
                                  IsNewReview = false;
                              }
                              else IsNewReview = true;
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
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
                      _main.CurrentViewModel = new ApplicationPageViewModel(SelectedApplication.Id);
                  }));
            }
        }

        Model.Review Review { get; set; }
        private RelayCommand _openReviewCommand;
        public RelayCommand OpenReviewCommand
        {
            get
            {
                return _openReviewCommand ??
                  (_openReviewCommand = new RelayCommand(obj =>
                  {
                      _main.CurrentViewModel = new ReviewViewModel(Review, SelectedApplication.Id);
                  }));
            }
        }

        private void OpenReviewAsync()
        {
            Review =  _accountService.GetReview(SelectedApplication.Id, AccountService.CurrentUser.Id);
        }

        public LibraryViewModel(MainViewModel main)
        {
            _main = main;
            _accountService = App.serviceProvider.GetService<IAccountService>();

            Applications = AccountService.CurrentUser.AvailableApplications;
        }
    }
}
