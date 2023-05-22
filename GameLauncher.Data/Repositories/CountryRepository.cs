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
    public class CountryRepository : ICountryRepository
    {
        private readonly GameLauncherContext _db;

        public CountryRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public Task Create(Country Entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Country Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Country> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Country> GetAll()
        {
            return _db.Countries.AsNoTracking();
        }

        public Task Update(Country Entity)
        {
            throw new NotImplementedException();
        }
    }
}
