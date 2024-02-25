namespace Interviewsystem.Persistence.Entities.Common;   
public class BaseEntity 
{
    public DateTime? CreatedOn { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public bool SoftDelete { get; set; } = false;   
}
