using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Results.CommentResults;
using Application.CQRS.Results.PostResults;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Read.Posts
{
    public class GetPostsQueryHandler
    {
        private IPostRepository _repository;

        public GetPostsQueryHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPostsQueryResult>> Handle()
        {
            List<Post> values = await _repository.GetAllAsync();

            return values.Select(x => new GetPostsQueryResult
            {
                Title = x.Title,
                PublishState = x.PublishState,
                Excerpt = x.Excerpt,
                Content = x.Content
            }).ToList();
        }
    }
}
