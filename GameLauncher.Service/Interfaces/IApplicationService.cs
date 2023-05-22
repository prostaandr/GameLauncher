using GameLauncher.Model;
using GameLauncher.Service.DTOs;
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
        Task<List<Application>> GetApplications();
        Task<int> GetReviewsPersent(List<Review> reviews);
        Task<List<Genre>> GetGenres();
    }
}
