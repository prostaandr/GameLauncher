using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(200)]
        public string? OS { get; set; }
        [MaxLength(200)]
        public string? Processor { get; set; }
        [MaxLength(200)]
        public string? Memory { get; set; }
        [MaxLength(200)]
        public string? Graphics { get; set; }
        [MaxLength(200)]
        public string? DirectX { get; set; }
        [MaxLength(200)]
        public string? Network { get; set; }
        [MaxLength(200)]
        public string? Storage { get; set; }

        public List<Application> MinApplications { get; set; } = new List<Application>();
        public List<Application> RecApplications { get; set; } = new List<Application>();
    }
}
