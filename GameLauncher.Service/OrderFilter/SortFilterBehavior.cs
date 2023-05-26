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
                default: throw new ArgumentNullException("Такой опции сортировки не существует");
            }
        }

        public static IQueryable<ApplicationDto> FilterApplicationsBy(this IQueryable<ApplicationDto> applications, ApplicationFilterOption options, object value)
        {
            switch (options)
            {
                case ApplicationFilterOption.ByGenre:
                    return applications.Where(a => a.GenreNames.Contains(value));
                case ApplicationFilterOption.ByFeature:
                    return applications.Where(a => a.FeatureNames.Contains(value));
                case ApplicationFilterOption.ByLanguage:
                    return applications.Where(a => a.LanguageNames.Contains(value));
                default: throw new ArgumentNullException("Такой опции фильтрации не существует");
            }
        }
    }
}
