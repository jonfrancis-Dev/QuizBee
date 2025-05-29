using System.ComponentModel.DataAnnotations;

public class QuizSubmission
{
    // This table represents one FULL Quiz attempt
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string UserEmail { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public ICollection<SubmittedAnswer> SubmittedAnswers { get; set; } = new List<SubmittedAnswer>();

}