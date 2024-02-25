using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            //RuleFor(u => u.UserId).Must(u => u > 0);
            RuleFor(e => e.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();
            RuleFor(p => p.Password).MinimumLength(8);
        }
    }
}
