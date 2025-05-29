using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerChoice> AnswerChoices { get; set; }
    public DbSet<QuizSubmission> QuizSubmissions { get; set; }
    public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Question>()
        .HasMany(q => q.Choices)
        .WithOne(a => a.Question)
        .HasForeignKey(a => a.QuestionId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<QuizSubmission>()
            .HasMany(qs => qs.SubmittedAnswers)
            .WithOne(sa => sa.QuizSubmission!)
            .HasForeignKey(sa => sa.QuizSubmissionId);
   
        builder.Entity<SubmittedAnswer>()
            .HasOne(sa => sa.Question)
            .WithMany()
            .HasForeignKey(sa => sa.QuestionId);

        builder.Entity<SubmittedAnswer>()
            .HasOne(sa => sa.SelectedChoice)
            .WithMany()
            .HasForeignKey(sa => sa.SelectedChoiceId);
    }
}
