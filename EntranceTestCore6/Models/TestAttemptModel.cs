using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntranceTestCore6.Models
{
    public class TestAttemptModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttemptId { get; set; }
        public int TestId { get; set; }
        public string? TestName { get; set; }
        public string? Email { get; set; }
        public DateTime TimeStart { get; set; }
        public int TestAmount { get; set; }
        public int AmountCorrect { get; set; }
        public bool IsFinish { get; set; }
        public double Accurate { get; set; }


    }
}