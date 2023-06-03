namespace EntranceTestCore6.Models
{
    public class UserModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public System.DateTime DateOfBirth { get; set; }
        public System.DateTime SignUpDate { get; set; }
        public int TestAmount { get; set; }
        public string Avatar { get; set; } = null!;
        public int? Status { get; set; }

    }
}
