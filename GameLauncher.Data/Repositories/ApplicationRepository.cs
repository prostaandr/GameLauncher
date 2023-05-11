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
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly GameLauncherContext _db;

        public ApplicationRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public async Task Create(Application Entity)
        {
            await _db.Applications.AddAsync(Entity);
            await _db.SaveChangesAsync();
        }

        // TODO: Метод не работает, программа виснит при его выполнении. Нужно понять почему.
        public async Task<Application> Get(int id)
        {
            var application = await _db.Applications
                                .AsNoTracking()
                                .SingleOrDefaultAsync(a => a.Id == id);
            return application;
        }

        public IQueryable<Application> GetAll()
        {
            return _db.Applications.AsNoTracking();
        }

        public async Task Update(Application Entity)
        {
            _db.Applications.Remove(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Application Entity)
        {
            _db.Applications.Remove(Entity);
            await _db.SaveChangesAsync();
        }
    }
}
