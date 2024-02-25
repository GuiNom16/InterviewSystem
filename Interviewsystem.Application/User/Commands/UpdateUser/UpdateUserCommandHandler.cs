using FluentValidation;
using Interviewsystem.Application.Responses;
using Interviewsystem.Application.Technology.Commands.UpdateTechnology;
using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ObjetRetour>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UpdateUserCommand> _validator;

        public UpdateUserCommandHandler(IUserRepository userRepository, IValidator<UpdateUserCommand> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<ObjetRetour> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
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
                        Profile = command.Profile,
                    };
                    await _userRepository.UpdateUser(user);
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
