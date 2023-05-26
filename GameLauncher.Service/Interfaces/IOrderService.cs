using GameLauncher.Model;
using GameLauncher.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder();
        Task AddOrderContent(int appId);
        Task RemoveOrderContent(int appId);
        Task CloserOrder();
        Task SetCurrentOrder();
        Task<int> GetTotalPrice();
        Task<IQueryable<ApplicationDto>> GetOrderContentApplications();
    }
}
