using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Entities;

namespace Interviewsystem.Persistence.Interfaces;   
public interface IUserRepository
{
    Task InsertUser(UserModel user);
    Task UpdateUser(UserModel user);
    Task DeleteUser(int id);
    Task<List<UserEntity>> GetUsersList();
    Task<string> Authenticate(UserModel user);
}
