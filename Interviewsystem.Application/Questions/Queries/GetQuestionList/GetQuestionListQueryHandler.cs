using Interviewsystem.Application.Responses;
using MediatR;

namespace Interviewsystem.Application.Questions.Queries.GetQuestionList;
public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, ObjetRetour>
{
    public Task<ObjetRetour> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
