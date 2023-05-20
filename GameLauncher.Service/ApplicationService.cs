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
        private readonly IReviewRepository _reviewRepository;
        private readonly IGenreRepository _genreRepository;

        public ApplicationService(IApplicationRepository applicationRepository, IReviewRepository reviewRepository, IGenreRepository genreRepository)
        {
            _applicationRepository = applicationRepository;
            _reviewRepository = reviewRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Application> GetApplication(int id)
        {
            return await _applicationRepository.Get(id); 
        }

        public async Task<List<Application>> GetApplications()
        {
            return await _applicationRepository.GetAll();
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await _genreRepository.GetAll();
        }

        public async Task<int> GetReviewsPersent(int id)
        {
            var reviews = await _reviewRepository.GetFromAppliation(id);

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
