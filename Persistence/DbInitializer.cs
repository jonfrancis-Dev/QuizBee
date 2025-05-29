using System;
using Domain.Entities;
using Microsoft.VisualBasic;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Questions.Any()) return; // Return if DB has already been seeded

        var questions = new List<Question>();

        // Could probably make this more concise if needed later (e.g var questions = new List<Question> {})
        var q1 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "How many soccer players should each team have on the field at the start of each match?",
            Hint = "It is the same amount of players on the field for American Football",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="7", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="8", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="11", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="14", IsCorrect = false}
                }
        };
        var q2 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What sport was Jesse Owens involved in?",
            Hint = "He made history at the 1936 Olympics with his speed.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Boxing", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Diving", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Gymnastics", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Track and Field", IsCorrect = true}
                }
        };
        var q3 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "Who is often called the father of the computer?",
            Hint = "He designed the Analytical Engine in the 1800s.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Alan Turing", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Blaise Pascal", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Charles Babbage", IsCorrect = true}
                }
        };
        var q4 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What was Twitter’s original name?",
            Hint = "It sounds like the current name, just lowercase.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Haikuu", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Hashtag", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="twitter", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Twitosphere", IsCorrect = false}
                }
        };
        var q5 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What part of the atom has no electric charge?",
            Hint = "It is neutral by nature.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Core", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Electron", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Neutron", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Proton", IsCorrect = false}
                }
        };
        var q6 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "Which natural disaster is measured with a Richter scale?",
            Hint = "This disaster shakes the ground.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Earthquakes", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="ELE", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Hurricanes", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Tsunami", IsCorrect = false}
                }
        };
        var q7 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "How many molecules of oxygen does ozone have",
            Hint = "It's one more than the oxygen you breathe",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="1", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="2", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="3", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="5", IsCorrect = false}
                }
        };
        var q8 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "Who is often credited with creating the world’s first car?",
            Hint = "His last name starts with 'B'.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Carroll Shelby", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Henry Ford", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Karl Benz", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Mario Bros", IsCorrect = false}
                }
        };
        var q9 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What or who is the Ford Mustang named after?",
            Hint = "It's an aircraft.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="A fighter plane from WWII", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Henry Ford’s daughter", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Wild horses in the Carolinas", IsCorrect = false},
                }
        };
        var q10 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "In what year was the Corvette introduced?",
            Hint = "It was the early 1950s.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="1919", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="1949", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="1953", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="1967", IsCorrect = false}
                }
        };
        var q11 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What is the common name for dried plums?",
            Hint = "They're popular in digestive health.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Anjeer", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Cashew", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Prunes", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Raisins", IsCorrect = false}
                }
        };
        var q12 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What’s the primary ingredient in hummus?",
            Hint = "It’s a small beige legume.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Avocados", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Chickpeas", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Olive Oil", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Salt", IsCorrect = false}
                }
        };
        var q13 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What is your body’s largest organ?",
            Hint = "It’s on the outside.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Kidney", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Lungs", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Skin", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Stomach", IsCorrect = false}
                }
        };
        var q14 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "Which bone are babies born without?",
            Hint = "It helps you kneel.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Kneecap", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Skull cap", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Sternum", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Tail bone", IsCorrect = false}
                }
        };
        var q15 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "About how many taste buds does the average human tongue have?",
            Hint = "It's a five-digit number.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="500", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="10,000", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="150,000", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="600,000", IsCorrect = false}
                }
        };
        var q16 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "How many times does the heart beat per day?",
            Hint = "It's over six figures.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="1,000", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="25,000", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="40,000", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="More than 100,000", IsCorrect = true}
                }
        };
        var q17 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What is the smallest country in the world?",
            Hint = "It’s located within Rome.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Monaco", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Nauru", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Pandora", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Vatican City", IsCorrect = true}
                }
        };
        var q18 = new Question
        {
            Id = Guid.NewGuid().ToString(),
            Text = "What is the name of the world’s longest river?",
            Hint = "It flows through Egypt.",
            Choices = new List<AnswerChoice>
                {
                    new () {Id = Guid.NewGuid().ToString(), Text="Amazon River", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Mississippi River", IsCorrect = false},
                    new () {Id = Guid.NewGuid().ToString(), Text="Nile", IsCorrect = true},
                    new () {Id = Guid.NewGuid().ToString(), Text="Niagara Falls", IsCorrect = false}
                }
        };

        // Add all questions to the List
        questions.AddRange(q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16, q17, q18);

        await context.Questions.AddRangeAsync(questions);
        await context.SaveChangesAsync();

    }

}
