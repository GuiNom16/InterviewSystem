using Interviewsystem.Domain.Enumerations;

namespace Interviewsystem.Domain.Models;
public class UserModel
{
    public int UserId { get; set; }
    public string? Fullname { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public byte Profile { get; set; }
}
