using System;
using Domain.Entities;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Questions.Any()) return; // Return if DB has already been seeded

        var questions = new List<Question>
        {
            // Add Questions and Choices
            new Question
            {
                Id = Guid.NewGuid().ToString(),
                Text = "",
                Hint = "",
                Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="", IsCorrect = false}
                }
            }
        };
    }

}
