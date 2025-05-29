using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class AnswerSelection
{
    // This table connects submitted answers to chosen choices. (Future Addition in client side)
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? SubmittedAnswerId { get; set; }
    public SubmittedAnswer? SubmittedAnswer { get; set; }
    public string? AnswerChoiceId { get; set; }
    public AnswerChoice? AnswerChoice { get; set; }
}
