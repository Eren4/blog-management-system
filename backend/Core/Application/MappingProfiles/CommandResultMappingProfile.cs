using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.CommentCommands;
using Application.CQRS.Commands.PostCommands;
using Application.CQRS.Commands.TagCommands;
using Application.CQRS.Results.CategoryResults;
using Application.CQRS.Results.CommentResults;
using Application.CQRS.Results.PostResults;
using Application.CQRS.Results.TagResults;
using AutoMapper;
using Domain.Models;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace Application.MappingProfiles
{
    public class CommandResultMappingProfile : Profile
    {
        public CommandResultMappingProfile()
        {
            // Post
            CreateMap<CreatePostCommand, Post>().ReverseMap();
            CreateMap<UpdatePostCommand, Post>().ReverseMap();
            CreateMap<RemovePostCommand, Post>().ReverseMap();

            CreateMap<GetPostByIdQueryResult, Post>().ReverseMap();
            CreateMap<GetPostsQueryResult, Post>().ReverseMap();

            // Comment
            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<UpdateCommentCommand, Comment>().ReverseMap();
            CreateMap<RemoveCommentCommand, Comment>().ReverseMap();

            CreateMap<GetCommentByIdQueryResult, Comment>().ReverseMap();
            CreateMap<GetCommentsQueryResult, Comment>().ReverseMap();

            // Category
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
            CreateMap<RemoveCategoryCommand, Category>().ReverseMap();

            CreateMap<GetCategoryByIdQueryResult, Category>().ReverseMap();
            CreateMap<GetCategoriesQueryResult, Category>().ReverseMap();

            // Tag
            CreateMap<CreateTagCommand, Tag>().ReverseMap();
            CreateMap<UpdateTagCommand, Tag>().ReverseMap();
            CreateMap<RemoveTagCommand, Tag>().ReverseMap();

            CreateMap<GetTagByIdQueryResult, Tag>().ReverseMap();
            CreateMap<GetTagsQueryResult, Tag>().ReverseMap();
        }
    }
}
