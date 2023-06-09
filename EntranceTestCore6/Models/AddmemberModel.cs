﻿using System.ComponentModel.DataAnnotations;

namespace EntranceTestCore6.Models

{
    public class AddMemberModel
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; } = null!;
        [Required]
        public int? Status { get; set; }
    }
}