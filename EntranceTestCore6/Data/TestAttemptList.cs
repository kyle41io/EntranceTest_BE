using AutoMapper.Execution;

namespace EntranceTestCore6.Data
{
    public class TestAttemptList
    {
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