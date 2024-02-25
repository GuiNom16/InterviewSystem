using Interviewsystem.Application.Responses;
using MediatR;
namespace Interviewsystem.Application.Questions.Commands.DeleteQuestion;
public class DeleteQuestionCommand: IRequest<ObjetRetour>
{
    public long Id { get; set; }
}
