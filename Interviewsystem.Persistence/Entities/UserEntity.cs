using Interviewsystem.Domain.Enumerations;
using Interviewsystem.Persistence.Entities.Common;

namespace Interviewsystem.Persistence.Entities;
public partial class UserEntity: BaseEntity
{
    public int UserId { get; set; }
    public string? Fullname { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public byte Profile { get; set; }
}
