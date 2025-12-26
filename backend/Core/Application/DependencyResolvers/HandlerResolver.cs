using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Handlers.Modify.Categories;
using Application.CQRS.Handlers.Modify.Comments;
using Application.CQRS.Handlers.Modify.Posts;
using Application.CQRS.Handlers.Modify.Tags;
using Application.CQRS.Handlers.Read.Comments;
using Application.CQRS.Handlers.Read.Posts;
using Application.CQRS.Handlers.Read.Tags;
using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Categories;

namespace Application.DependencyResolvers
{
    public static class HandlerResolver
    {
        public static void AddHandlerService(this IServiceCollection services)
        {
            // Posts
            services.AddScoped<GetPostsQueryHandler>();
            services.AddScoped<GetPostByIdQueryHandler>();
            services.AddScoped<CreatePostCommandHandler>();
            services.AddScoped<UpdatePostCommandHandler>();
            services.AddScoped<RemovePostCommandHandler>();
            services.AddScoped<SoftDeletePostCommandHandler>();

            // Comments
            services.AddScoped<GetCommentsQueryHandler>();
            services.AddScoped<GetCommentByIdQueryHandler>();
            services.AddScoped<CreateCommentCommandHandler>();
            services.AddScoped<UpdateCommentCommandHandler>();
            services.AddScoped<RemoveCommentCommandHandler>();
            services.AddScoped<SoftDeleteCommentCommandHandler>();

            // Categories
            services.AddScoped<GetCategoriesQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<SoftDeleteCategoryCommandHandler>();

            // Tags
            services.AddScoped<GetTagsQueryHandler>();
            services.AddScoped<GetTagByIdQueryHandler>();
            services.AddScoped<CreateTagCommandHandler>();
            services.AddScoped<UpdateTagCommandHandler>();
            services.AddScoped<RemoveTagCommandHandler>();
            services.AddScoped<SoftDeleteTagCommandHandler>();
        }
    }
}
