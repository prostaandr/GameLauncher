using GameLauncher.Model.Enum;
using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.DTOs
{
    public class ApplicationDetailDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int ActualPrice { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
        public string LanguagesLine { get; set; }
        public string GenresLine { get; set; }
        public string FeaturesLine { get; set; }
        public string DeveloperName { get; set; }
        public string PublisherName { get; set; }
        public int? ParentId { get; set; }
        public SystemRequirements? MinimumSystemRequirements { get; set; }
        public SystemRequirements? RecommendedSystemRequirements { get; set; }
        public List<Media> Medias { get; set; } = new List<Media>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public int ReviewsPercent { get; set; }
    }
}
