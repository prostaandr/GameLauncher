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
    public class ReviewRepository : IReviewRepository
    {
        private readonly GameLauncherContext _db;

        public ReviewRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public async Task Create(Review Entity)
        {
            await _db.Reviews.AddAsync(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Review> Get(int id)
        {
            return await _db.Reviews.AsNoTracking().SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Review>> GetAll()
        {
            return await _db.Reviews.AsNoTracking().ToListAsync();
        }

        public async Task Update(Review Entity)
        {
            _db.Reviews.Update(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Review Entity)
        {
            _db.Reviews.Remove(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Review>> GetFromAppliation(int applicationId)
        {
            return await _db.Reviews.AsNoTracking().Where(a => a.ApplicationId == applicationId).ToListAsync();
        }
    }
}
