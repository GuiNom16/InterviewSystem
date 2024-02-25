using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Entities;
using Interviewsystem.Persistence.Interfaces;
using Interviewsystem.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Interviewsystem.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly InterviewsystemContext context;
    private readonly IConfiguration config;
    public UserRepository(InterviewsystemContext context, IConfiguration config)
    {
        this.context = context;
        this.config = config;
    }

    public async Task<string> Authenticate(UserModel userModel)
    {
        var user = context.Users.FirstOrDefault(u => u.Login == userModel.Login);
        if (user is null) throw new InvalidOperationException("No users found");
        if (user.Password != userModel.Password)
        {
            throw new InvalidOperationException("Credentials do not match existing user");
        }
        //Token generation (put it in helper later)
        var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]));
        var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(config["JwtSettings:Issuer"], config["JwtSettings:Audience"],
            null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task DeleteUser(int id)
    {
        var user = new UserEntity();
        if(id > 0)
        {
            user = context.Users.FirstOrDefault(u => u.UserId == id);
        }

        if(user != null)
        {
            user.SoftDelete = true;
            await context.SaveChangesAsync();
        }
    }

    public async Task InsertUser(UserModel user)
    {
        await context.Users.AddAsync(new UserEntity
        {
            CreatedOn = DateTime.Now,
            Fullname = user.Fullname,
            Login = user.Login,
            Password = user.Password,
            Profile = user.Profile,
        });
        await context.SaveChangesAsync();
    }

    public async Task UpdateUser(UserModel user)
    {
        context.Update(new UserEntity
        {
            UpdatedOn = DateTime.Now,
            Fullname = user.Fullname,
            Login = user.Login,
            Password = user.Password,
            Profile = user.Profile,
        });
        await context.SaveChangesAsync();
    }

    public async Task<List<UserEntity>> GetUsersList()
    {
        var userList = await context.Users.Where(u => !u.SoftDelete).ToListAsync();
        return userList is null ? throw new InvalidOperationException("No users found") : userList;
    }
}
