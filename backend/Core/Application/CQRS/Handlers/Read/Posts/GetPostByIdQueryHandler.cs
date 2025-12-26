using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Queries.CommentQueries;
using Application.CQRS.Queries.PostQueries;
using Application.CQRS.Results.CommentResults;
using Application.CQRS.Results.PostResults;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Read.Posts
{
    public class GetPostByIdQueryHandler
    {
        private IPostRepository _repository;

        public GetPostByIdQueryHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPostByIdQueryResult> Handle(GetPostByIdQuery query)
        {

            Post value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
                return null;

            return new GetPostByIdQueryResult
            {
                Id = value.Id,
                Content = value.Content,
                Excerpt = value.Excerpt,
                PublishState = value.PublishState,
                Title = value.Title
            };
        }
    }
}
