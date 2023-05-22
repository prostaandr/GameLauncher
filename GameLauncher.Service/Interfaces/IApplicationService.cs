using GameLauncher.Model;
using GameLauncher.Service.DTOs;
using GameLauncher.Service.OrderFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationDetailDto> GetApplication(int id);
        Task<IQueryable<ApplicationDto>> GetApplications(ApplicationSortOptions sortOptions);
        Task<int> GetReviewsPersent(int appId);
        IQueryable<Genre> GetGenres();
    }
}
