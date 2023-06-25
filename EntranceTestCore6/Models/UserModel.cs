using System.ComponentModel.DataAnnotations;

namespace EntranceTestCore6.Models

{
    public class UserModel
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
        public string PhoneNumber { get; set; } = null!;
        public int TestAmount { get; set; }
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; } = null!;
        [Required]
        public Boolean? isAdmin { get; set; }
        [Required]
        public Boolean? isActive { get; set; }
    }
}