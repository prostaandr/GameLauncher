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
    public class GenreRepository : IGenreRepository
    {
        private readonly GameLauncherContext _db;

        public GenreRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public Task Create(Genre Entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Genre Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Genre> GetAll()
        {
            return _db.Genres.AsNoTracking();
        }

        public Task Update(Genre Entity)
        {
            throw new NotImplementedException();
        }
    }
}
