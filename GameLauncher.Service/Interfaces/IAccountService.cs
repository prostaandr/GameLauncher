using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.Interfaces
{
    public interface IAccountService
    {
        Task Registration(User user);
        Task<User> GetUser(int id);
        Task<User> Login(string login, string password);
        IQueryable<Country> GetAllCountries();
        Task AddAvalableApplication(int appId);
        List<Application> GetAvalable(int id);
        Review GetReview(int applicationId, int userId);
    }
}
