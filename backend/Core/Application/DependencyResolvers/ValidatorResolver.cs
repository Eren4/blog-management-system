using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Validators.Category;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Application.Validators.Comment;
using Application.Validators.Post;
using Application.Validators.Tag;

namespace Application.DependencyResolvers
{
    public static class ValidatorResolver
    {
        public static void AddValidatorService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryCommandValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateCommentCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCommentCommandValidator>();

            services.AddValidatorsFromAssemblyContaining<CreatePostCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdatePostCommandValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateTagCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateTagCommandValidator>();
        }
    }
}
