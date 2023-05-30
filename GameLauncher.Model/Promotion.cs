using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("Promotion")]
    public class Promotion
    {
        public int Id { get; set; }
        public int NewPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Application Application { get; set; }
    }
}
