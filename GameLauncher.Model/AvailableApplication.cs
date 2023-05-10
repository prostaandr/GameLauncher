using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    public class AvailableApplication
    {
        public int? UserId { get; set; }
        public User? User { get; set; }

        public int? ApplicationId { get; set; }
        public Application? Application { get; set; }
    }
}
