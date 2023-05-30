using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("Country")]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? FlagUrl { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
