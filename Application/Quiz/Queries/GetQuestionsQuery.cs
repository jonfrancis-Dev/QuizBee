using System;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Migrations;

namespace Application.Quiz.Queries;

public class GetQuestionsQuery
{
    public class Query : IRequest<List<Question>> { }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Query, List<Question>>
    {
        public async Task<List<Question>> Handle(Query request, CancellationToken cancellationToken)
        {
            var questions =  await context.Questions
                .Include(q => q.Choices)
                .ToListAsync(cancellationToken);

            // Randomize the list and only choose 10
            var random = new Random();
            return questions.OrderBy(q=>random.Next()).Take(10).ToList();
        }
    }
}
