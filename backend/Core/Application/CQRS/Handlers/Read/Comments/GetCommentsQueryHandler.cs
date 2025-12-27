using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Results.CategoryResults;
using Application.CQRS.Results.CommentResults;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Read.Comments
{
    public class GetCommentsQueryHandler
    {
        private ICommentRepository _repository;

        public GetCommentsQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentsQueryResult>> Handle()
        {
            List<Comment> values = await _repository.GetAllAsync();

            return values.Select(x => new GetCommentsQueryResult
            {
                Id = x.Id,
                Text = x.Text,
                AuthorName = x.AuthorName,
                ApproveState = x.ApproveState,
                PostId = x.PostId
            }).ToList();
        }
    }
}
