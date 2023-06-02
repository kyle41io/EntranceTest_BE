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
/*
        public DbSet<Member> Members { get; set; }
        public DbSet<TestList> TestLists { get; set; }
        public DbSet<QuestionList> QuestionLists { get; set; }
        public DbSet<TestAttemptList> TestAttemptLists { get; set; }
        public DbSet<TestQuestionAttemptList> TestQuestionAttemptLists { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasKey(m => m.MemberId);
            modelBuilder.Entity<TestList>().HasKey(t => t.TestId);
            modelBuilder.Entity<QuestionList>().HasKey(q => q.QuestionId);
            modelBuilder.Entity<TestAttemptList>().HasKey(a => a.AttemptId);
            modelBuilder.Entity<TestQuestionAttemptList>().HasKey(aq => aq.AttemptQuestionId);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.TestAttemptLists)
                .WithOne(t => t.Member)
                .HasForeignKey(t => t.MemberId);

            modelBuilder.Entity<TestList>()
                .HasMany(t => t.QuestionLists)
                .WithOne(q => q.TestList)
                .HasForeignKey(q => q.TestId);

            modelBuilder.Entity<TestList>()
                .HasMany(t => t.TestAttemptLists)
                .WithOne(a => a.TestList)
                .HasForeignKey(a => a.TestId);

            modelBuilder.Entity<QuestionList>()
                .HasMany(q => q.TestQuestionAttemptLists)
                .WithOne(a => a.QuestionList)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<TestAttemptList>()
                .HasMany(a => a.TestQuestionAttemptLists)
                .WithOne(a => a.TestAttemptList)
                .HasForeignKey(a => a.AttemptId);
        }*/
    }

}


