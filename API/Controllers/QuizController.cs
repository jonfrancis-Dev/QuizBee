using Application.Exceptions;
using Application.Quiz.Commands;
using Application.Quiz.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await Mediator.Send(new GetQuestionsQuery.Query());
            return Ok(questions);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAnswers([FromBody] SubmitAnswersCommand.Command command) // Accepts JSON Body w/ Email & Answers
        {
            // Wrap in try catch in case user email is duplicate
            try
            {
                var result = await Mediator.Send(command);
                return Ok(new  // This is a better way to return than before
                {
                    message = "Quiz submitted successfully!",
                    score = result.TotalScore,
                    percentage = result.Percentage,
                    submissionId = result.Id
                });
            }
            catch (AppException ex)
            {
                return BadRequest(new
                {
                    error = "Submission failed",
                    reason = ex.Message
                });
            }
        }
    }
}
