using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetByLogin(string login);
        public Task<List<Application>> GetAvailableApplications(int userId, int applicationId);
    }
}
