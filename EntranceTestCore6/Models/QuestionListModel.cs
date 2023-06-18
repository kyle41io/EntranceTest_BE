using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntranceTestCore6.Models
{
    public class QuestionListModel
    {
        public int TestId { get; set; }
        public string? TestName { get; set; }
        public string? Question { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public int CorrectAnswer { get; set; }
    }
}