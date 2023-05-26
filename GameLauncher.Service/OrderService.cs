﻿using GameLauncher.Data.Interfaces;
using GameLauncher.Model;
using GameLauncher.Service.DTOs;
using GameLauncher.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationService _applicationService;

        public Order CurrentOrder { get; set; }

        public OrderService(IOrderRepository orderRepository, IApplicationRepository applicationRepository, IApplicationService applicationService)
        {
            _orderRepository = orderRepository;
            _applicationRepository = applicationRepository;
            _applicationService = applicationService;
        }

        public async Task CreateOrder()
        {
            await _orderRepository.Create(new Order
            {
                UserId = AccountService.CurrentUser.Id,
                Date = DateTime.Now,
                TotalPrice = 0,
                IsClose = false,
            });
        }

        public async Task AddOrderContent(int appId)
        {
            await SetCurrentOrder();
            await Task.Delay(100);
            var application = await _applicationRepository.GetForOrder(appId);
            await _orderRepository.AddContent(CurrentOrder.Id, appId);
            CurrentOrder.TotalPrice += application.Price;

            await _orderRepository.Update(CurrentOrder);
        }


        public async Task RemoveOrderContent(int appId)
        {
           
            var application = await _applicationRepository.GetForOrder(appId);
            await _orderRepository.DeleteContent(CurrentOrder.Id, appId);
            CurrentOrder.TotalPrice -= application.Price;

            await _orderRepository.Update(CurrentOrder);
        }

        public async Task CloserOrder()
        {
            CurrentOrder.IsClose = true;
            await SetCurrentOrder();
        }

        public async Task SetCurrentOrder()
        {
            CurrentOrder = Task.FromResult(await _orderRepository.GetCurrent()).Result;
            if (CurrentOrder == null)
            {
                await CreateOrder();
                CurrentOrder = Task.FromResult(await _orderRepository.GetCurrent()).Result;
            }
        }

        public async Task<int> GetTotalPrice()
        {
            return CurrentOrder.TotalPrice;
        }

        public async Task<IQueryable<ApplicationDto>> GetOrderContentApplications()
        {
            await SetCurrentOrder();
            await Task.Delay(100);
            var dtos = new List<ApplicationDto>();

            for (int i = 0; i < CurrentOrder.Applications.Count; i++)
            {
                var dto = new ApplicationDto
                {
                    Id = CurrentOrder.Applications[i].Id,
                    Name = CurrentOrder.Applications[i].Name,
                    ReleaseDate = CurrentOrder.Applications[i].ReleaseDate,
                    Price = CurrentOrder.Applications[i].Price,
                    PosterUrl = CurrentOrder.Applications[i].PosterUrl,
                    ApplicationType = CurrentOrder.Applications[i].ApplicationType,
                    GenreNames = CurrentOrder.Applications[i].Genres.Select(g => g.Name).ToList(),
                    FeatureNames = CurrentOrder.Applications[i].Features.Select(g => g.Name).ToList(),
                    LanguageNames = CurrentOrder.Applications[i].Languages.Select(g => g.Name).ToList(),
                    ReviewsPercent = await _applicationService.GetReviewsPersent(CurrentOrder.Applications[i].Id)
                };

                dtos.Add(dto);
            }
            return dtos.AsQueryable();
        }
    }
}
