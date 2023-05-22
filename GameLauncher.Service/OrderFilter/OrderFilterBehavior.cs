using GameLauncher.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.OrderFilter
{
    public static class OrderFilterBehavior
    {
        // Application
        public static IQueryable<ApplicationDetailDto> OrderApplicationBy(this IQueryable<ApplicationDetailDto> applications, ApplicationOrderOptions options)
        {
            switch (options)
            {
                case ApplicationOrderOptions.Simple: 
                    return applications.OrderByDescending(a => a.Id);
                case ApplicationOrderOptions.ByName:
                    return applications.OrderBy(a => a.Name);
                case ApplicationOrderOptions.ByReviews:
                    return applications.OrderByDescending(a => a.ReviewsPercent);
                case ApplicationOrderOptions.ByPriceAsc:
                    return applications.OrderBy(a => a.Price);
                case ApplicationOrderOptions.ByPriceDesc:
                    return applications.OrderByDescending(a => a.Price);
                case ApplicationOrderOptions.ByRealeseDateAsc:
                    return applications.OrderBy(a => a.ReleaseDate);
                case ApplicationOrderOptions.ByRealeseDateDesc:
                    return applications.OrderByDescending(a => a.ReleaseDate);
                default: throw new ArgumentNullException("Такой опции сортировани не существует");
            }
        }
    }
}
