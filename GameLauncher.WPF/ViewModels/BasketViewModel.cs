using GameLauncher.Service;
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
using System.Windows;

namespace GameLauncher.WPF.ViewModels
{
    class BasketViewModel : BaseViewModel
    {
        MainViewModel _main;
        private IApplicationService _applicationService;
        private IOrderService _orderService;
        private IAccountService _accountService;

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
                      RemoveAsync(Convert.ToInt32(obj));
                      SetApplications();
                  }));
            }
        }

        private async void RemoveAsync(int id)
        {
            await _orderService.RemoveOrderContent(id);
        }

        private RelayCommand _buyCommand;
        public RelayCommand BuyCommand
        {
            get
            {
                return _buyCommand ??
                  (_buyCommand = new RelayCommand(obj =>
                  {
                      BuyAsync();
    
                      MessageBox.Show("Покупка завершилась успешно");
                  }));
            }
        }

        private async void BuyAsync()
        {
            foreach (var app in Applications)
            {
                await _accountService.AddAvalableApplication(app.Id);
            }
            await _orderService.CloseOrder();
            Applications = new List<ApplicationDto> { };
            TotalPrice = 0;
        }

        public BasketViewModel(MainViewModel main)
        {
            _main = main;
            _applicationService = App.serviceProvider.GetService<IApplicationService>();
            _orderService = App.serviceProvider.GetService<IOrderService>();
            _accountService = App.serviceProvider.GetService<IAccountService>();

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
        }
    }
}
