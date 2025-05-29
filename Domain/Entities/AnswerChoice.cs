using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class AnswerChoice
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Text { get; set; } // Answer Choice (e.g "Track and Field")
    public bool IsCorrect { get; set; }
    [ForeignKey("QuestionId")]
    public required string QuestionId { get; set; } // Foreign Key to the Question
    public required Question Question { get; set; }
}
