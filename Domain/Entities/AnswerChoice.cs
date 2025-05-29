using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class AnswerChoice
{
    // This table holds all the answer choices for Questions
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Text { get; set; } // Answer Choice (e.g "Track and Field")
    public bool IsCorrect { get; set; }
    [ForeignKey("QuestionId")]
    public string? QuestionId { get; set; } // Foreign Key to the Question
    [JsonIgnore]
    public Question? Question { get; set; }
}
