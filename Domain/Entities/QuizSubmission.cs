using System.ComponentModel.DataAnnotations;

public class QuizSubmission
{
    // This table tracks a user's entire quiz attempt.
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string UserEmail { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public ICollection<SubmittedAnswer> SubmittedAnswers { get; set; } = new List<SubmittedAnswer>();

    // Scoring Properties
    public int TotalScore { get; set; } = 0;

    // This property is not stored in DB
    public double Percentage => Math.Round((double)TotalScore / 10 * 100, 2); // 10 is the max score

}