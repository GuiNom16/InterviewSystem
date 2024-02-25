using Interviewsystem.Application.Questions.Commands.CreateQuestion;
using Interviewsystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection.Metadata.Ecma335;

namespace Interviewsystem.Api.Controllers
{
    [Route("interviewsystem")]
    public class QuestionController : ControllerBase
    {
        private readonly ISender _mediator;
        public QuestionController(ISender _mediator)
        {
            this._mediator = _mediator;
        }
        [HttpPost("addQuestion")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<ActionResult<ObjetRetour>> AddQuestion([FromBody] CreateQuestionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
