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

        public AccountService(IUserRepository userRepository, ICountryRepository countryRepository)
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository; 
        }

        public async Task AddUser(User user)
        {
            await _userRepository.Create(user);
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _countryRepository.GetAll();
        }
    }
}
