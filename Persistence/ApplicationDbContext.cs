using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerChoice> AnswerChoices { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Question>()
        .HasMany(q => q.Choices)
        .WithOne(a => a.Question)
        .HasForeignKey(a => a.QuestionId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
