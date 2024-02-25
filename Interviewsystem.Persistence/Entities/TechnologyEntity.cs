using Interviewsystem.Persistence.Entities.Common;

namespace Interviewsystem.Persistence.Entities;
public partial class TechnologyEntity: BaseEntity
{
    public TechnologyEntity()
    {
        Questions = new HashSet<QuestionEntity>();
    }

    public int TechnoId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<QuestionEntity> Questions { get; set; }
}
