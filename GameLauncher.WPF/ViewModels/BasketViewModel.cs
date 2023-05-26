using GameLauncher.Service.DTOs;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.WPF.ViewModels
{
    class BasketViewModel : BaseViewModel
    {
        MainViewModel _main;
        private IApplicationService _applicationService;
        private IOrderService _orderService;

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

        private ObservableCollection<ApplicationViewModel> _applicationsVM;
        public ObservableCollection<ApplicationViewModel> ApplicationsVM
        {
            get => _applicationsVM;
            set
            {
                if (value == _applicationsVM) return;
                _applicationsVM = value;
                OnPropertyChanged();
            }
        }



        private int _totalPrice;
        public int TotalPrice
        {
            get => _totalPrice;
            set
            {
                if (value == _totalPrice) return;
                _totalPrice = value;
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

        private RelayCommand _removeGameCommand;
        public RelayCommand RemoveGameCommand
        {
            get
            {
                return _removeGameCommand ??
                  (_removeGameCommand = new RelayCommand(obj =>
                  {
                      _orderService.RemoveOrderContent(Convert.ToInt32(obj));
                      Applications.Remove(Applications.FirstOrDefault(a => a.Id == Convert.ToInt32(obj)));
                      _orderService.SetCurrentOrder();
                      SetApplications();
                  }));
            }
        }

        public BasketViewModel(MainViewModel main)
        {
            _main = main;
            _applicationService = App.serviceProvider.GetService<IApplicationService>();
            _orderService = App.serviceProvider.GetService<IOrderService>();

            InitializeAsync();
        }

        private async void SetApplications()
        {
            Applications = (await _orderService.GetOrderContentApplications()).ToList();
            TotalPrice = await _orderService.GetTotalPrice();
        }

        private async void InitializeAsync()
        {
            SetApplications();
            ApplicationsVM = new ObservableCollection<ApplicationViewModel>();
            //foreach (var application in Applications)
            //{
            //    ApplicationsVM.Add(new ApplicationViewModel() { Application = application });
            //}
        }
    }
}
