using Interviewsystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Commands.AuthenticateUser
{
    public class AuthUserCommand : IRequest<ObjetRetour>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
