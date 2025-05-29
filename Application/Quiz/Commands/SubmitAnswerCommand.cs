using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Quiz.Commands;

public class SubmitAnswersCommand
{
    public class Command : IRequest<QuizSubmission>
    {
        public string UserEmail { get; set; } = null!;
        public List<AnswerSubmissionDto> Answers { get; set; } = new();
    }

    public class AnswerSubmissionDto
    {
        public string QuestionId { get; set; } = null!;
        public string SelectedChoiceId { get; set; } = null!;
    }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Command, QuizSubmission>
    {
        public async Task<QuizSubmission> Handle(Command request, CancellationToken cancellationToken)
        {
            var submission = new QuizSubmission
            {
                UserEmail = request.UserEmail,
                SubmittedAt = DateTime.UtcNow
            };

            int totalScore = 0;

            foreach (var answer in request.Answers)
            {
                var selectedChoice = await context.AnswerChoices
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == answer.SelectedChoiceId, cancellationToken);

                if (selectedChoice == null)
                    throw new Exception($"Answer choice with ID '{answer.SelectedChoiceId}' not found.");

                if (selectedChoice.IsCorrect)
                    totalScore += 1;

                submission.SubmittedAnswers.Add(new SubmittedAnswer
                {
                    QuestionId = answer.QuestionId,
                    SelectedChoiceId = answer.SelectedChoiceId,
                    QuizSubmission = submission,
                    QuizSubmissionId = submission.Id
                });
            }

            submission.TotalScore = totalScore;

            context.QuizSubmissions.Add(submission);
            await context.SaveChangesAsync(cancellationToken);

            return submission;
        }
    }
}
