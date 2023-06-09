using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntranceTestCore6.Data

{
    public class TestQuestionAttemptList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttemptQuestionId { get; set; }
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
        public int Chose { get; set; }
        public int CorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }

    }
}