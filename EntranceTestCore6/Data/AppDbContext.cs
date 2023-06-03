using EntranceTestCore6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace EntranceTestCore6.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TestList> TestLists { get; set; }
        public DbSet<QuestionList> QuestionLists { get; set; }
        public DbSet<TestAttemptList> TestAttemptLists { get; set; }
        public DbSet<TestQuestionAttemptList> TestQuestionAttemptLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestList>().HasKey(t => t.TestId);
            modelBuilder.Entity<QuestionList>().HasKey(q => q.QuestionId);
            modelBuilder.Entity<TestAttemptList>().HasKey(a => a.AttemptId);
            modelBuilder.Entity<TestQuestionAttemptList>().HasKey(aq => aq.AttemptQuestionId);

            
        }
    }

}


