using GameLauncher.Model.Enum;
using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.DTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int ActualPrice { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
        public List<string> LanguageNames { get; set; } = new List<string>();
        public List<string> FeatureNames { get; set; } = new List<string>();
        public List<string> GenreNames { get; set; } = new List<string>();
        public int ReviewsPercent { get; set; }
    }
}
