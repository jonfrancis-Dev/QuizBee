using Application.Exceptions;
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
        public List<string> SelectedChoiceIds { get; set; } = new();
    }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Command, QuizSubmission>
    {
        public async Task<QuizSubmission> Handle(Command request, CancellationToken cancellationToken)
        {
            // Check if a submission already exists for this email
            var existingSubmission = await context.QuizSubmissions
                .AnyAsync(s => s.UserEmail == request.UserEmail, cancellationToken);

            if (existingSubmission)
            {
                throw new AppException(
                    $"A quiz submission has already been received for '{request.UserEmail}'. " +
                    $"Each user may only submit once.");
            }

            var submission = new QuizSubmission
            {
                UserEmail = request.UserEmail,
                SubmittedAt = DateTime.UtcNow
            };

            int totalScore = 0;

            // Loop through each answers and get correct choice id(s)
            foreach (var answer in request.Answers)
            {
                var correctChoiceIds = await context.AnswerChoices
                    .AsNoTracking()
                    .Where(c => c.QuestionId == answer.QuestionId && c.IsCorrect)
                    .Select(c => c.Id)
                    .ToListAsync(cancellationToken);

                // No correct choices are missing
                // No extra (incorrect) choices are selected
                var isFullyCorrect = !correctChoiceIds.Except(answer.SelectedChoiceIds).Any() // All that are correct
                                     && !answer.SelectedChoiceIds.Except(correctChoiceIds).Any();

                if (isFullyCorrect)
                    totalScore += 1;

                foreach (var choiceId in answer.SelectedChoiceIds)
                {
                    submission.SubmittedAnswers.Add(new SubmittedAnswer
                    {
                        QuestionId = answer.QuestionId,
                        SelectedChoiceId = choiceId,
                        QuizSubmission = submission,
                        QuizSubmissionId = submission.Id
                    });
                }
            }

            submission.TotalScore = totalScore;

            context.QuizSubmissions.Add(submission);
            await context.SaveChangesAsync(cancellationToken);

            return submission;
        }
    }
}
