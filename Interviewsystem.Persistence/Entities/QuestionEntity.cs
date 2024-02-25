using Interviewsystem.Persistence.Entities.Common;

namespace Interviewsystem.Persistence.Entities;
public partial class QuestionEntity: BaseEntity
{
    public long QuestionId { get; set; }
    public string? QuestionContent { get; set; }
    public int? TechnoId { get; set; }
    public string? AnswerElement { get; set; }
    public byte? QuestionLevel { get; set; }
    public virtual TechnologyEntity? Techno { get; set; }
}
