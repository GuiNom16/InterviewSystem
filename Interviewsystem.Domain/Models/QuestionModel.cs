namespace Interviewsystem.Domain.Models;
public class QuestionModel
{
    public long QuestionId { get; set; }
    public string? QuestionContent { get; set; }
    public int? TechnoId { get; set; }
    public string? AnswerElement { get; set; }
    public byte? QuestionLevel { get; set; }
    public virtual TechnologyModel? Techno { get; set; }
}
