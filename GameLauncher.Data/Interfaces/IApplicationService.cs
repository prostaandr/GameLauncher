using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data.Interfaces
{
    public interface IApplicationService
    {
        Task<Application> GetApplication(int id);
        Task<List<Application>> GetApplications();
    }
}
