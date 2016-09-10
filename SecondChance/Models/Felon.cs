﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondChance.Models
{
    public class Felon
    {
        public int FelonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]
        public string AboutMe { get; set; }
        [Required]
        public string FeloniesCommitted { get; set; }
        public string Skill1 { get; set; }
        public string Skill2 { get; set; }
        public string  Skill3 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Email { get; set; }

    }
}