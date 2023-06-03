namespace EntranceTestCore6.Data
{
    public class QuestionList
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public string? TestName { get; set; }
        public string? Question { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public int CorrectAnswer { get; set; }
        public TestList? TestList { get; set; }
        public ICollection<TestQuestionAttemptList>? TestQuestionAttemptLists { get; set; }
    }
}