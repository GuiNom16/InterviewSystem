using FluentValidation;
using Interviewsystem.Application.Responses;
using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ObjetRetour>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<DeleteUserCommand> _validator;

        public DeleteUserCommandHandler(IUserRepository userRepository, IValidator<DeleteUserCommand> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<ObjetRetour> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var retour = new ObjetRetour();
            var validator = await _validator.ValidateAsync(command);

            if (validator.Errors.Count > 0)
            {
                retour.Etat = false;

                foreach (var error in _validator.Validate(command).Errors)
                {
                    retour.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (retour.Etat == true)
            {
                try
                {
                    var user = new UserModel
                    {
                        UserId = command.UserId,
                    };

                    await _userRepository.DeleteUser(user.UserId);

                    retour.Etat = true;
                    retour.Message = "Success";
                }
                catch (Exception ex)
                {
                    retour.Etat = false;
                    retour.Message = ex.Message;
                }
            }

            return retour;
        }
    }
}
