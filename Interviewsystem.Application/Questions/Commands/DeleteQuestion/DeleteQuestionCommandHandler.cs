using Interviewsystem.Application.Responses;
using MediatR;
namespace Interviewsystem.Application.Questions.Commands.DeleteQuestion;
public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, ObjetRetour>
{
    public Task<ObjetRetour> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
