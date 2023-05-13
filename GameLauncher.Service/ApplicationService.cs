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
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<Application> GetApplication(int id)
        {
            return await _applicationRepository.Get(id); 
        }

        public async Task<List<Application>> GetApplications()
        {
            return await _applicationRepository.GetAll();
        }
    }
}
