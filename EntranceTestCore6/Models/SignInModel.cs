﻿using System.ComponentModel.DataAnnotations;

namespace EntranceTestCore6.Models
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public Boolean isAdmin { get; set; } 
        
    }
}
