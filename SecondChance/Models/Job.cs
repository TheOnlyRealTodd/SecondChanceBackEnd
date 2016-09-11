using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondChance.Models
{
    public class Job
    {
        public int JobId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        public bool HasGed { get; set; }
        public Employer Employer { get; set; }
    }
}