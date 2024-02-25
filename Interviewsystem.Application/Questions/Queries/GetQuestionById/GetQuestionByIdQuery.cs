using Interviewsystem.Application.Responses;
using MediatR;
namespace Interviewsystem.Application.Questions.Queries.GetQuestionById;    
public class GetQuestionByIdQuery: IRequest<ObjetRetour>
{
    public long Id { get; set; }
}
