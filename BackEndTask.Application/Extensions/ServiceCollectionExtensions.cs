using BackEndTask.Application.CommentService;
using BackEndTask.Application.JwtSettings;
using BackEndTask.Application.PostServices;
using BackEndTask.Application.Services;
using BackEndTask.Application.UserServices;
using Microsoft.Extensions.DependencyInjection;
namespace BackEndTask.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ICommentService, Services.CommentService>();
        services.AddScoped<IPostService, Services.PostService>();
        services.AddScoped<IUserServices, UserServices.UserService>();
        services.AddSingleton<JwtToken>();
    }
}