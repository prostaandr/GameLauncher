using GameLauncher.Data.Interfaces;
using GameLauncher.Model;
using GameLauncher.Service.DTOs;
using GameLauncher.Service.Interfaces;
using GameLauncher.Service.OrderFilter;
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

        public ApplicationService(IApplicationRepository applicationRepository, IReviewRepository reviewRepository, IGenreRepository genreRepository)
        {
            _applicationRepository = applicationRepository;
            _reviewRepository = reviewRepository;
            _genreRepository = genreRepository;
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
                Reviews = app.Reviews,
                ReviewsPercent = await GetReviewsPersent(app.Reviews)
            };

            return dto;
        }

        public async Task<IQueryable<ApplicationDto>> GetApplications(ApplicationSortOptions sortOptions)
        {
            var applications = _applicationRepository.GetAll().ToList();

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
                    Genres = applications[i].Genres,
                    Features = applications[i].Features,
                    Languages = applications[i].Languages,
                    ReviewsPercent = await GetReviewsPersent(applications[i].Reviews)
                };

                dtos.Add(dto);
            }
            return await Task.FromResult(dtos.AsQueryable().OrderApplicationsBy(sortOptions));
        }

        public IQueryable<Genre> GetGenres()
        {
            return _genreRepository.GetAll();
        }

        public async Task<int> GetReviewsPersent(List<Review> reviews)
        {
            var positiveCount = 0;
            foreach (var review in reviews)
            {
                if (review.Grade == 0) positiveCount++;
            }

            if (positiveCount == 0) return 0;
            return positiveCount * 100 / reviews.Count;
        }
    }
}
