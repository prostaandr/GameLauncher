using GameLauncher.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("Media")]
    public class Media
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public MediaTypeEnum MediaType { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();
    }
}