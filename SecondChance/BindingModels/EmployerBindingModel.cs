using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SecondChance.Models;

namespace SecondChance.BindingModels
{
    public class EmployerBindingModel
    {
        public int EmployerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}