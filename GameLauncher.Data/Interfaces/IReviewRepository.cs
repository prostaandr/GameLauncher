using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        IQueryable<Review> GetFromAppliation(int applicationId);
        Review Get(int applicationId, int userId);
    }
}
