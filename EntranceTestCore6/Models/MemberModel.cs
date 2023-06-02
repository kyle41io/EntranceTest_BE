﻿using System.ComponentModel.DataAnnotations;
using EntranceTestCore6.Data;

namespace EntranceTestCore6.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string? MemberName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public System.DateTime SignUpDate { get; set; }
        public int TestAmount { get; set; }
        public string Avatar { get; set; } = String.Empty;
        public string? Status { get; set; }
        public ICollection<TestAttemptList>? TestAttemptLists { get; set; }
    }
}
