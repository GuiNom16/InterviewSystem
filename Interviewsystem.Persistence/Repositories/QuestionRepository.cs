using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Interfaces;
using Interviewsystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interviewsystem.Persistence.Repositories;
public class QuestionRepository : IQuestionRepository
{
    private readonly InterviewsystemContext context;    
    public QuestionRepository(InterviewsystemContext context)   
    {
        this.context = context;
    }
    public async Task<QuestionModel> FindQuestionById(int id)
    {
        var question = await context.Questions.FirstOrDefaultAsync(q => q.QuestionId == id);
        return new QuestionModel { 
            AnswerElement = question?.AnswerElement,
            QuestionContent = question?.QuestionContent,
            QuestionId = question?.QuestionId ?? 0,
            TechnoId = question?.TechnoId,
            QuestionLevel = question?.QuestionLevel,
            Techno= new TechnologyModel
            {
                TechnoId = question?.TechnoId ?? 0,
                Title = question?.Techno?.Title
            }
        };
    }

    public async Task InsertQuestion(QuestionModel question)
    {
        await context.Questions.AddAsync(new QuestionEntity { 
            AnswerElement = question?.AnswerElement,
            CreatedOn = DateTime.Now,
            QuestionContent = question?.QuestionContent,
            QuestionLevel = question?.QuestionLevel,
            TechnoId = question?.TechnoId
        });
        await context.SaveChangesAsync();
    }
        
    public Task<IReadOnlyList<IEnumerable<QuestionModel>>> QuestionPagedAsync(int page, int size)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateQuestion(QuestionModel question)
    {
        context.Update(new QuestionEntity { 
            QuestionContent = question.QuestionContent,
            QuestionLevel = question.QuestionLevel,
            TechnoId = question.TechnoId,
            AnswerElement = question.AnswerElement,
            UpdatedOn = DateTime.Now,
            QuestionId = question.QuestionId
        });
        await context.SaveChangesAsync();
    }
}
