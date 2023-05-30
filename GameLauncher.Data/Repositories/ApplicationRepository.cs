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

        public async Task<Application> Get(int id)
        {
            return await _db.Applications
                .AsSplitQuery()
                .Include(a => a.Developer)
                .Include(a => a.Publisher)
                .Include(a => a.Features)
                .Include(a => a.Genres)
                .Include(a => a.Languages)
                .Include(a => a.MinimumSystemRequirements)
                .Include(a => a.RecommendedSystemRequirements)
                .Include(a => a.Medias)
                .Include(a => a.Reviews)
                .ThenInclude(r => r.User)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Application> GetForOrder(int id)
        {
            return await _db.Applications
                .AsSplitQuery()
                .Include(a => a.Developer)
                .Include(a => a.Publisher)
                .Include(a => a.Features)
                .Include(a => a.Genres)
                .Include(a => a.Languages)
                .Include(a => a.MinimumSystemRequirements)
                .Include(a => a.RecommendedSystemRequirements)
                .Include(a => a.Medias)
                .Include(a => a.Reviews)
                .ThenInclude(r => r.User)
                .SingleOrDefaultAsync(a => a.Id == id);
        }


        public IQueryable<Application> GetAll()
        {
            return _db.Applications
                .AsNoTracking()
                .Include(a => a.Genres)
                .Include(a => a.Features)
                .Include(a => a.Languages);
        }

        public IQueryable<Application> GetAll(string searchValue)
        {
            return _db.Applications
                .AsNoTracking()
                .Include(a => a.Genres)
                .Include(a => a.Features)
                .Include(a => a.Languages)
                .Where(a => EF.Functions.Like(a.Name, "%" + searchValue + "%"));
        }

        public async Task Update(Application Entity)
        {
            _db.Applications.Update(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Application Entity)
        {
            _db.Applications.Remove(Entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Developer> GetDevelopers()
        {
            return _db.Developers.AsNoTracking();
        }

        public IQueryable<Publisher> GetPublishers()
        {
            return _db.Publishers.AsNoTracking();
        }
    }
}
