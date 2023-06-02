namespace EntranceTestCore6.Data

{
    public class TestList
  {
    public int TestId { get; set; }
    public string? TestName { get; set; }
    public int QuestionAmount { get; set; }
    public TimeSpan TestTime { get; set; }
    public string? TestDesc { get; set; }
    public ICollection<QuestionList>? QuestionLists { get; set; }
    public ICollection<TestAttemptList>? TestAttemptLists { get; set; }
  }
}