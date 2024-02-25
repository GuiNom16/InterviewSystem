using Interviewsystem.Domain.Models;
namespace Interviewsystem.Persistence.Interfaces;   
public interface IQuestionRepository
{
    Task InsertQuestion(QuestionModel question);
    Task UpdateQuestion(QuestionModel question);
    Task<IReadOnlyList<IEnumerable<QuestionModel>>> QuestionPagedAsync(int page, int size);
    Task<QuestionModel> FindQuestionById(int id);
}
