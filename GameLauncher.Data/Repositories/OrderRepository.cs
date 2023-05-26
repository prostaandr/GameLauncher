using GameLauncher.Data.Interfaces;
using GameLauncher.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GameLauncherContext _db;

        public OrderRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public async Task Create(Order Entity)
        {
            await _db.Orders.AddAsync(Entity);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Order Entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteContent(int orderId, int appId)
        {
            _db.Orders.Find(orderId).Applications.Remove(_db.Applications.Find(appId));
            await _db.SaveChangesAsync();
        }

        public async Task AddContent(int orderId, int appId)
        {
            _db.Orders.Find(orderId).Applications.Add(_db.Applications.Find(appId));
            await _db.SaveChangesAsync();
        }

        public Task<Order> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetCurrent()
        {
            return await _db.Orders
                .Include(o => o.Applications)
                .FirstOrDefaultAsync(o => o.IsClose == false);
        }

        public async Task Update(Order Entity)
        {
            _db.Orders.Update(Entity);
            await _db.SaveChangesAsync();
        }
    }
}
