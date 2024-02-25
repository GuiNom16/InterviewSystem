using Interviewsystem.Application.Responses;
using MediatR;

namespace Interviewsystem.Application.Questions.Commands.CreateQuestion;
public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, ObjetRetour>
{
    public Task<ObjetRetour> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
