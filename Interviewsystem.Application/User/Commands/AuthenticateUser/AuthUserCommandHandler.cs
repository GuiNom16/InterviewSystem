using Interviewsystem.Application.Responses;
using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Commands.AuthenticateUser
{
    public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, ObjetRetour>
    {
        private readonly IUserRepository userRepository;

        public AuthUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ObjetRetour> Handle(AuthUserCommand command, CancellationToken cancellationToken)
        {
            var retour = new ObjetRetour();
            try
            {
                var user = new UserModel
                {
                    Login = command.Login,
                    Password = command.Password,
                };
                retour.Contenu = await userRepository.Authenticate(user);
                retour.Message = "Success";
            }
            catch (Exception ex)
            {
                retour.Etat = false;
                retour.Message = ex.Message;
            }
            return retour;
        }
    }
}
