using GameLauncher.Model.Enum;
using System;
using System.Collections.Generic;
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
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }

        public int? ParentId { get; set; }
        public Application? Parent { get; set; }

        public int? DeveloperId { get; set; }
        public Developer? Developer { get; set; }

        public int? MinimumSystemRequirementsId { get; set; }
        public SystemRequirements? MinimumSystemRequirements { get; set; }

        public int? RecommendedSystemRequirementsId { get; set; }
        public SystemRequirements? RecommendedSystemRequirements { get; set; }

        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public List<Language> Language { get; set; } = new List<Language>();
        public List<Feature> Feature { get; set; } = new List<Feature>();
        public List<Genre> Genre { get; set; } = new List<Genre>();
        public List<Promotion> Promotion { get; set; } = new List<Promotion>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<AvailableApplication> AvailableApplications { get; set; } = new List<AvailableApplication>();
        public List<WishList> WishListApplication { get; set; } = new List<WishList>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
