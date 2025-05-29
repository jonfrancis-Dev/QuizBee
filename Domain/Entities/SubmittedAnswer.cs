using System.ComponentModel.DataAnnotations;
using Domain.Entities;

public class SubmittedAnswer
{
    // This table represents ONE Question's answer in that attempt
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string QuestionId { get; set; }
    public Question? Question { get; set; }

    public required string SelectedChoiceId { get; set; }
    public AnswerChoice? SelectedChoice { get; set; } 

    public bool IsCorrect { get; set; }

    public required string QuizSubmissionId { get; set; }
    public QuizSubmission? QuizSubmission { get; set; }
}