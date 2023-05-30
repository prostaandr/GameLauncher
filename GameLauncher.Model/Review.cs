using GameLauncher.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("Review")]
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public ReviewGradeEnum Grade { get; set; }
        public DateTime Date { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
