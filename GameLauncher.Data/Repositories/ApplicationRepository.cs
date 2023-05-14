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
            return await _db.Applications.AsNoTracking()
                .AsSplitQuery()
                .Include(a => a.Developer)
                .Include(a => a.Publisher)
                .Include(a => a.Features)
                .Include(a => a.Genres)
                .Include(a => a.Languages)
                .Include(a => a.MinimumSystemRequirements)
                .Include(a => a.RecommendedSystemRequirements)
                .Include(a => a.Medias)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Application>> GetAll()
        {
            return await _db.Applications.AsNoTracking().ToListAsync();
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
