using GameLauncher.Data.Interfaces;
using GameLauncher.Model;
using GameLauncher.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICountryRepository _countryRepository;

        public static User CurrentUser { get; set; }

        public AccountService(IUserRepository userRepository, ICountryRepository countryRepository)
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
        }

        public async Task Registration(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь оказался null");
            }

            await _userRepository.Create(user);
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            if (user == null || user.Password != password)
            {
                throw new ArgumentException("Неправильный логин или пароль");
            }

            return user;
        }

        public IQueryable<Country> GetAllCountries()
        {
            return _countryRepository.GetAll();
        }

        public async Task AddAvalableApplication(int appId)
        {
            await _userRepository.AddAvalaibleApplication(CurrentUser.Id, appId);
        }
    }
}
