using Interviewsystem.Application.Responses;
using Interviewsystem.Application.User.Commands.AuthenticateUser;
using Interviewsystem.Application.User.Commands.CreateUser;
using Interviewsystem.Application.User.Commands.DeleteUser;
using Interviewsystem.Application.User.Commands.UpdateUser;
using Interviewsystem.Application.User.Queries.GetUsersList;
using Interviewsystem.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interviewsystem.Api.Controllers
{
    [Route("interviewsystem")]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;
        public UserController(ISender mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<ObjetRetour>> AuthenticateUser([FromBody] AuthUserCommand command)
        {
            if(command != null)
            {
                var result = await _mediator.Send(command, CancellationToken.None);
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost("addUser")]
        public async Task<ActionResult<ObjetRetour>> AddNewUser([FromBody] CreateUserCommand command)
        {
            if (command != null)
            {
                var result = await _mediator.Send(command, CancellationToken.None);
                return Ok(result);
            }
            return BadRequest();
        }

    
        [HttpPatch("updateUser")]
        public async Task<ActionResult<ObjetRetour>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            if (command != null)
            {
                var result = await _mediator.Send(command, CancellationToken.None);
                return Ok(result);
            }
            return BadRequest();
        }

      
        [HttpDelete("deleteUser")]
        public async Task<ActionResult<ObjetRetour>> DeleteUser(int id)
        {
            if (id > 0)
            {
                var command = new DeleteUserCommand() { UserId = id };
                var result = await _mediator.Send(command, CancellationToken.None);
                return Ok(result);
            }
            return BadRequest();
        }


        [Authorize]
        [HttpGet("getUsersList")]
        public async Task<ActionResult<ObjetRetour>> GetUsersList([FromQuery] GetUsersListQuery query)
        {
            if (query != null)
            {
                var result = await _mediator.Send(query, CancellationToken.None);
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
