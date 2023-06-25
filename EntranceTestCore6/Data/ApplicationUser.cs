using Microsoft.AspNetCore.Identity;

namespace EntranceTestCore6.Data
{
  public class ApplicationUser : IdentityUser
    { 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public System.DateTime DateOfBirth { get; set; } 
        public System.DateTime SignUpDate { get; set; }
        public int TestAmount { get; set; }
        public string Avatar { get; set; } = null!;
        public Boolean? isAdmin { get; set; }
        public Boolean? isActive { get; set; }
        public ICollection<TestAttempt>? TestAttemps { get; set; }

    }
}