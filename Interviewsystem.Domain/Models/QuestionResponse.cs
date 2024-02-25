namespace Interviewsystem.Domain.Models;
public class QuestionResponse
{
    public long QuestionId { get; set; }
    public byte Rating { get; set; } 
    public string QuestionComment { get; set; } = string.Empty;
}