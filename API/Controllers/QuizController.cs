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
    }
}
