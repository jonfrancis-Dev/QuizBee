using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class AnswerChoice
{
    // This table holds all the answers for each Question
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Text { get; set; } // Answer Choice (e.g "Track and Field")
    public bool IsCorrect { get; set; }
    [ForeignKey("QuestionId")]
    public string? QuestionId { get; set; }
    [JsonIgnore]
    public Question? Question { get; set; }
}
