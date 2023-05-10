using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
