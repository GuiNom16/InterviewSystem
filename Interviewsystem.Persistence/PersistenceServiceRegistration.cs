using Interviewsystem.Persistence.Interfaces;
using Interviewsystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Interviewsystem.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection PersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InterviewsystemContext>(options =>
        options.UseSqlServer(configuration["ConnectionStrings:InterviewSystemConnectionString"] ?? ""));
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

