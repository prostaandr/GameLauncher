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
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public int ReviewsPercent { get; set; }
    }
}
