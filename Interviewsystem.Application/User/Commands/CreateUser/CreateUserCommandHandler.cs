﻿using FluentValidation;
using Interviewsystem.Application.Responses;
using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ObjetRetour>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IUserRepository userRepository, IValidator<CreateUserCommand> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }
        public async Task<ObjetRetour> Handle(CreateUserCommand command, CancellationToken cancellationToken)
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
            if (retour.Etat)
            {
                try
                {
                    var user = new UserModel
                    {
                        Fullname = command.FullName,
                        Login = command.Email,
                        Password = command.Password,
                        Profile = command.Profile,
                    };
                    await _userRepository.InsertUser(user);
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
