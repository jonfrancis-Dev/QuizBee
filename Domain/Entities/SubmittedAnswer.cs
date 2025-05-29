using System.ComponentModel.DataAnnotations;
using Domain.Entities;

public class SubmittedAnswer
{
    // This table links each question to user’s selected answers.
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? QuestionId { get; set; }
    public Question? Question { get; set; }

    public string? QuizSubmissionId { get; set; }
    public QuizSubmission? QuizSubmission { get; set; }

    public string? SelectedChoiceId { get; set; }

    public AnswerChoice? SelectedChoice { get; set; }

    public ICollection<AnswerSelection> SelectedChoices { get; set; } = new List<AnswerSelection>();
}