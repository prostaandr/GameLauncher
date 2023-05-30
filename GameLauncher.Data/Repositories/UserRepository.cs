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
    public class UserRepository : IUserRepository
    {
        private readonly GameLauncherContext _db;

        public UserRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public async Task Create(User Entity)
        {
            await _db.Users.AddAsync(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _db.Users.AsNoTracking().Include(u => u.AvailableApplications).SingleOrDefaultAsync(a => a.Id == id);
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users.AsNoTracking();
        }

        public async Task Update(User Entity)
        {
            _db.Users.Update(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(User Entity)
        {
            _db.Users.Remove(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _db.Users.AsNoTracking().Include(u => u.AvailableApplications).SingleOrDefaultAsync(a => a.Login == login);
        }

        public async Task AddAvalaibleApplication(int userId, int appId)
        {
            _db.Users.Find(userId).AvailableApplications.Add(_db.Applications.Find(appId));
            await _db.SaveChangesAsync();
        }

        public List<Application> GetAvalable(int userId)
        {
            _db.Entry(_db.Users.SingleOrDefault(u => u.Id == userId)).Collection(u => u.AvailableApplications).Load();
            return null;
        }
    }
}