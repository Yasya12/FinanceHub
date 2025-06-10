using System.Reflection;
using FinanceGub.Application.Interfaces;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Repositories;
using FinanceHub.Infrastructure.Services;
using FinanceHub.Infrastructure.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceHub.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy",
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IPostRepository, PostRepository>();
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<IPostCategoryRepository, PostCategoryRepository>();
        serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
        serviceCollection.AddScoped<ILikeRepository, LikeRepository>();
        serviceCollection.AddScoped<IPostImageRepository, PostImageRepository>();
        serviceCollection.AddScoped<IMessageRepository, MessageRepository>();
        serviceCollection.AddScoped<IHubRepository, HubRepository>();
        serviceCollection.AddScoped<IHubMemberRepository, HubMemberRepository>();
        serviceCollection.AddScoped<IHubJoinRequestRepository, HubJoinRequestRepository>();
        serviceCollection.AddScoped<INotificationRepository, NotificationRepository>();
        serviceCollection.AddScoped<IFollowingRepository, FollowingRepository>();
        
        serviceCollection.AddScoped<IUserService, UserService>(); 
        serviceCollection.AddScoped<IJwtService, JwtService>();
        serviceCollection.AddScoped<IPostService, PostService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<ICommentService, CommentService>();
        serviceCollection.AddScoped<ILikeService, LikeService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IMessageService, MessageService>();
        serviceCollection.AddScoped<ILikeHub, LikeHub>();
        serviceCollection.AddScoped<INotificationService, NotificationService>();
        serviceCollection.AddScoped<IFollowingService, FollowingService>();
        serviceCollection.AddScoped<IEmailService, EmailService>();
        serviceCollection.AddScoped<ISearchService, SearchService>();
         
        
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
    
    
}