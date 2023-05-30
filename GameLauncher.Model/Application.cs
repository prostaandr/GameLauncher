using GameLauncher.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("Application")]
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }

        public int? ParentId { get; set; }
        public Application? Parent { get; set; }

        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public int MinimumSystemRequirementsId { get; set; }
        public SystemRequirements MinimumSystemRequirements { get; set; }

        public int RecommendedSystemRequirementsId { get; set; }
        public SystemRequirements RecommendedSystemRequirements { get; set; }

        public List<Language> Languages { get; set; } = new List<Language>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Media> Medias { get; set; } = new List<Media>();
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
