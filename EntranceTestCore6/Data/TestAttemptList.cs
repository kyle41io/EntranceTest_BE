namespace EntranceTestCore6.Data
{
    public class TestAttemptList
  {
    public int AttemptId { get; set; }
    public int TestId { get; set; }
    public string? TestName { get; set; }
    public int MemberId { get; set; }
    public DateTime TimeStart { get; set; }
    public int TestAmount { get; set; }
    public int AmountCorrect { get; set; }
    public bool IsFinish { get; set; }
    public double Accurate { get; set; }
    public Member? Member { get; set; }
    public TestList? TestList { get; set; }
    public ICollection<TestQuestionAttemptList>? TestQuestionAttemptLists { get; set; }
  }
}