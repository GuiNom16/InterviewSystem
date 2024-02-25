using FluentValidation;
using Interviewsystem.Application.Technology.Commands.CreateTechnology;
using Interviewsystem.Application.User.Commands;
using Interviewsystem.Application.User.Commands.CreateUser;
using Interviewsystem.Application.User.Commands.DeleteUser;
using Interviewsystem.Application.User.Commands.UpdateUser;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Interviewsystem.Application;
public static class ApplicationServiceRegistration
{   
    public static IServiceCollection ApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
        services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();
        return services;
    }
}
