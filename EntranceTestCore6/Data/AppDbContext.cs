using EntranceTestCore6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EntranceTestCore6.Models;

namespace EntranceTestCore6.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TestAttempt> TestAttempts { get; set; }
        public DbSet<TestQuestionAttempt> TestQuestionAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>().HasKey(t => t.TestId);
            modelBuilder.Entity<Question>().HasKey(q => q.QuestionId);
            modelBuilder.Entity<TestAttempt>().HasKey(a => a.AttemptId);
            modelBuilder.Entity<TestQuestionAttempt>().HasKey(aq => aq.AttemptQuestionId);
            

            modelBuilder.Entity<Test>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId);

           
        }

        
    }

}


