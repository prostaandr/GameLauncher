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
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Login { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
        [MinLength(6)]
        [MaxLength(30)]
        public string Password { get; set; }
        [MaxLength(30)]
        public string Nickname { get; set; }
        public string? IconUrl { get; set; }
        [MaxLength(20)]
        public UserRoleEnum Role { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Application> AvailableApplications { get; set; } = new List<Application>();
        public List<Application> WishListApplications { get; set; } = new List<Application>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
