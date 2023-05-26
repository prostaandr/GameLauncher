using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetCurrent();
        Task DeleteContent(int orderId, int appId);
        Task AddContent(int orderId, int appId);
    }
}
