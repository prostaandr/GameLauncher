using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model
{
    [Table("SystemRequirements")]
    public class SystemRequirements
    {
        public int Id { get; set; }
        public string? OS { get; set; }
        public string? Processor { get; set; }
        public string? Memory { get; set; }
        public string? Graphics { get; set; }
        public string? DirectX { get; set; }
        public string? Network { get; set; }
        public string? Storage { get; set; }
    }
}
