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
    public class FeatureRepository : IFeatureRepository
    {
        private readonly GameLauncherContext _db;

        public FeatureRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public Task Create(Feature Entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Feature Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Feature> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Feature> GetAll()
        {
            return _db.Features.AsNoTracking();
        }

        public Task Update(Feature Entity)
        {
            throw new NotImplementedException();
        }
    }
}
