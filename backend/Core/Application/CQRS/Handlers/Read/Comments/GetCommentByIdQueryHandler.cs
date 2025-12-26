using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Queries.CommentQueries;
using Application.CQRS.Results.CategoryResults;
using Application.CQRS.Results.CommentResults;
using Contract.RepositoryInterfaces;
using Domain.Models;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;

namespace Application.CQRS.Handlers.Read.Comments
{
    public class GetCommentByIdQueryHandler
    {
        private ICommentRepository _repository;

        public GetCommentByIdQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery query)
        {

            Comment value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
                return null;

            return new GetCommentByIdQueryResult
            {
                Id = value.Id,
                AuthorName = value.AuthorName,
                Text = value.Text,
                ApproveState = value.ApproveState
            };
        }
    }
}
