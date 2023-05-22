using GameLauncher.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.OrderFilter
{
    public static class SortFilterBehavior
    {
        // Application
        public static IQueryable<ApplicationDto> OrderApplicationsBy(this IQueryable<ApplicationDto> applications, ApplicationSortOptions options)
        {
            switch (options)
            {
                case ApplicationSortOptions.Simple: 
                    return applications.OrderByDescending(a => a.Id);
                case ApplicationSortOptions.ByName:
                    return applications.OrderBy(a => a.Name);
                case ApplicationSortOptions.ByReviews:
                    return applications.OrderByDescending(a => a.ReviewsPercent);
                case ApplicationSortOptions.ByPriceAsc:
                    return applications.OrderBy(a => a.Price);
                case ApplicationSortOptions.ByPriceDesc:
                    return applications.OrderByDescending(a => a.Price);
                case ApplicationSortOptions.ByRealeseDateAsc:
                    return applications.OrderBy(a => a.ReleaseDate);
                case ApplicationSortOptions.ByRealeseDateDesc:
                    return applications.OrderByDescending(a => a.ReleaseDate);
                default: throw new ArgumentNullException("Такой опции сортировани не существует");
            }
        }
    }
}
