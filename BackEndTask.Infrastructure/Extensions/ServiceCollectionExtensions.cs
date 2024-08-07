using BackEndTask.Domain.Repositories;
using BackEndTask.Infrastructure.Persistance;
using BackEndTask.Infrastructure.Repositories;
using BackEndTask.Infrastructure.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndTask.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services,
     IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BackEndTask"));
        });

        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
    }
}