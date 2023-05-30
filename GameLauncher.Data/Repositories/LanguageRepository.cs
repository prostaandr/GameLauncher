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
    public class LanguageRepository : ILanguageRepository
    {
        private readonly GameLauncherContext _db;

        public LanguageRepository(GameLauncherContext db)
        {
            _db = db;
        }

        public Task Create(Language Entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Language Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Language> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Language> GetAll()
        {
            return _db.Languages;
        }

        public Task Update(Language Entity)
        {
            throw new NotImplementedException();
        }
    }
}
