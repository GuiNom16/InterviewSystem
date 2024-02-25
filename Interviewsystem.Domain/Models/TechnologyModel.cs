namespace Interviewsystem.Domain.Models;
public class TechnologyModel
{
    public int TechnoId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<QuestionModel>? Questions { get; set; }
}
