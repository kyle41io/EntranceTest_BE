using System.ComponentModel.DataAnnotations;

namespace EntranceTestCore6.Models

{
    public class AdminModUserModel
    {
        [Required]
        public string? Id  { get; set; }
        [Required]
        public Boolean? isAdmin { get; set; }
        [Required]
        public Boolean? isActive { get; set; }
    }
}