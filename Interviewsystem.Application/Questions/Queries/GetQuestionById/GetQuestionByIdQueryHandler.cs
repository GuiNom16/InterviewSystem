using Interviewsystem.Application.Responses;
using MediatR;
namespace Interviewsystem.Application.Questions.Queries.GetQuestionById;    

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, ObjetRetour>
{
    public Task<ObjetRetour> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
