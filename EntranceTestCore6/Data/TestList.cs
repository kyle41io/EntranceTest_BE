using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntranceTestCore6.Data

{
    public class TestList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestId { get; set; }
        public string? TestName { get; set; }
        public int QuestionAmount { get; set; }
        public System.TimeSpan TestTime { get; set; }
        public string? TestDesc { get; set; }
       
    }
}