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
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
