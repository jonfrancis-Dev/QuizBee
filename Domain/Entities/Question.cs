using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Question
{
    // This table holds all the possible questions and hints 
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Text { get; set; } // Quiz Question
    public string? Hint { get; set; } // Hint is optional
    public ICollection<AnswerChoice> Choices { get; set; } = new List<AnswerChoice>(); // List of Choices
}
