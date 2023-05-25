using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.OrderFilter
{
    public enum ApplicationSortOptions
    {
        [Description("По имени")]
        ByName,
        [Description("По отзывам")]
        ByReviews,
        [Description("По цене (↑)")]
        ByPriceAsc,
        [Description("По цене (↓)")]
        ByPriceDesc,
        [Description("По дате выхода (↑)")]
        ByRealeseDateAsc,
        [Description("По дате выхода (↓)")]
        ByRealeseDateDesc,
        
    }
}
