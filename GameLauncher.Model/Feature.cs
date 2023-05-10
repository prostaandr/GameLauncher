using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("Feature")]
    public class Feature
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
