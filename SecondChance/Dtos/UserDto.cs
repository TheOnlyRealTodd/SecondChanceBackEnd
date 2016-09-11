using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondChance
{
    public class UserDto
    {

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsEmployer{ get; set; }

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]
        public string AboutMe { get; set; }
        [Required]
        public string FeloniesCommitted { get; set; }
        public string Skill1 { get; set; }
        public string Skill2 { get; set; }
        public string Skill3 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

    }
}