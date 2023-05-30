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
        Task<Application> GetApplicationForSet(int id);
        Task<IQueryable<ApplicationDto>> GetApplications(string searchValue, ApplicationSortOptions sortOptions, Dictionary<string, ApplicationFilterOption> filters);
        Task<int> GetReviewsPersent(int appId);
        IQueryable<Genre> GetGenres();
        IQueryable<Feature> GetFeatures();
        IQueryable<Language> GetLanguages();
        Task SetReview(Review review, bool isNew);
        Review GetReview(int appId, int userId);
        IQueryable<Developer> GetDevelopers();
        IQueryable<Publisher> GetPublishers();
        Task SetApplication(Application application, bool isNew);
    }
}
