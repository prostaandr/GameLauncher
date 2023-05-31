using GameLauncher.Data.Interfaces;
using GameLauncher.Model;
using GameLauncher.Service.DTOs;
using GameLauncher.Service.Interfaces;
using GameLauncher.Service.OrderFilter;
using Microsoft.EntityFrameworkCore;
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
        private readonly IReviewRepository _reviewRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IFeatureRepository _featureRepository;
        private readonly ILanguageRepository _languageRepository;

        public ApplicationService(IApplicationRepository applicationRepository, IReviewRepository reviewRepository, IGenreRepository genreRepository,
            IFeatureRepository featureRepository, ILanguageRepository languageRepository)
        {
            _applicationRepository = applicationRepository;
            _reviewRepository = reviewRepository;
            _genreRepository = genreRepository;
            _featureRepository = featureRepository;
            _languageRepository = languageRepository;
        }

        public async Task<ApplicationDetailDto> GetApplication(int id)
        {
            var app = await _applicationRepository.Get(id);

            var dto = new ApplicationDetailDto
            {
                Id = app.Id,
                Name = app.Name,
                Description = app.Description,
                Price = app.Price,
                PosterUrl = app.PosterUrl,
                ReleaseDate = app.ReleaseDate,
                ApplicationType = app.ApplicationType,
                LanguagesLine = String.Join(", ", app.Languages.Select(l => l.Name)),
                FeaturesLine = String.Join(", ", app.Features.Select(f => f.Name)),
                GenresLine = String.Join(", ", app.Genres.Select(g => g.Name)),
                DeveloperName = app.Developer.Name,
                PublisherName = app.Publisher.Name,
                ParentId = app.ParentId,
                MinimumSystemRequirements = app.MinimumSystemRequirements,
                RecommendedSystemRequirements = app.RecommendedSystemRequirements,
                Medias = app.Medias,
                Reviews = await _reviewRepository.GetFromAppliation(app.Id).ToListAsync(),
                ReviewsPercent = await GetReviewsPersent(app.Id)
            };

            return await Task.FromResult(dto);
        }

        public async Task<IQueryable<ApplicationDto>> GetApplications(string searchValue, ApplicationSortOptions sortOptions, Dictionary<string, ApplicationFilterOption> filters)
        {
            List<Application> applications;

            if (!String.IsNullOrEmpty(searchValue))
            {
                applications = await _applicationRepository.GetAll(searchValue).ToListAsync();
            }
            else applications = await _applicationRepository.GetAll().ToListAsync();

            var dtos = new List<ApplicationDto>();

            for (int i = 0; i < applications.Count; i++)
            {
                var dto = new ApplicationDto
                {
                    Id = applications[i].Id,
                    Name = applications[i].Name,
                    ReleaseDate = applications[i].ReleaseDate,
                    Price = applications[i].Price,
                    PosterUrl = applications[i].PosterUrl,
                    ApplicationType = applications[i].ApplicationType,
                    GenreNames = applications[i].Genres.Select(g => g.Name).ToList(),
                    FeatureNames = applications[i].Features.Select(g => g.Name).ToList(),
                    LanguageNames = applications[i].Languages.Select(g => g.Name).ToList(),
                    ReviewsPercent = await GetReviewsPersent(applications[i].Id)
                };

                dtos.Add(dto);
            }

            var qDtos = dtos.AsQueryable();

            qDtos = qDtos.OrderApplicationsBy(sortOptions);

            foreach (var filter in filters)
            {
                qDtos = qDtos.FilterApplicationsBy(filter.Value, filter.Key);
            }

            return qDtos;
        }

        public IQueryable<Genre> GetGenres()
        {
            return _genreRepository.GetAll();
        }

        public IQueryable<Feature> GetFeatures()
        {
            return _featureRepository.GetAll();
        }

        public IQueryable<Language> GetLanguages()
        {
            return _languageRepository.GetAll();
        }

        public async Task<int> GetReviewsPersent(int appId)
        {
            var reviews = await _reviewRepository.GetFromAppliation(appId).ToListAsync();

            var positiveCount = 0;
            foreach (var review in reviews)
            {
                if (review.Grade == 0) positiveCount++;
            }

            if (positiveCount == 0) return 0;
            return positiveCount * 100 / reviews.Count;
        }


        public async Task SetReview(Review review, bool isNew)
        {
            if (isNew)
            {
                await _reviewRepository.Create(review);
            }
            else
            {
                await _reviewRepository.Update(review);
            }
        }

        public Review GetReview(int appId, int userId)
        {
            return _reviewRepository.Get(appId, userId);
        }

        public async Task<Application> GetApplicationForSet(int id)
        {
            return await _applicationRepository.Get(id);
        }

        public IQueryable<Developer> GetDevelopers()
        {
            return _applicationRepository.GetDevelopers();
        }

        public IQueryable<Publisher> GetPublishers()
        {
            return _applicationRepository.GetPublishers();
        }

        public async Task SetApplication(Application application, bool isNew)
        {
            if (isNew)
            {
                await _applicationRepository.Create(application);
            }
            else
            {
                await _applicationRepository.Update(application);
            }
        }

        public async Task DeleteApplication(Application app)
        {
            await _applicationRepository.Delete(app);
        }
    }
}
