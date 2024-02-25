using FluentValidation;
namespace Interviewsystem.Application.Questions.Commands.CreateQuestion;
public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(c => c.QuestionId)
            .Must(i => i == 0).WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required");
        RuleFor(c => c.QuestionLevel)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .WithMessage("{PropertyName} is required");
    }
}
