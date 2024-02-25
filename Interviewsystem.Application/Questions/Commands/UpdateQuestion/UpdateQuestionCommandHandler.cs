using Interviewsystem.Application.Responses;
using MediatR;
namespace Interviewsystem.Application.Questions.Commands.UpdateQuestion;
public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, ObjetRetour>
{
    public Task<ObjetRetour> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
