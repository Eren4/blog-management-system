using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.CommentCommands;
using Contract.RepositoryInterfaces;
using Domain.Models;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace Application.CQRS.Handlers.Modify.Comments
{
    public class CreateCommentCommandHandler
    {
        private ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommand command)
        {
            await _repository.CreateAsync(new Comment
            {
                AuthorName = command.AuthorName,
                Text = command.Text,
                PostId = command.PostId,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
