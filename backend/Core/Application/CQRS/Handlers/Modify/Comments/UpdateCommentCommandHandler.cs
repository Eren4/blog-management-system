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
    public class UpdateCommentCommandHandler
    {
        private ICommentRepository _repository;

        public UpdateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comment> Handle(UpdateCommentCommand command)
        {
            Comment value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            value.AuthorName = command.AuthorName;
            value.Text = command.Text;
            value.PostId = command.PostId;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();

            return value;
        }
    }
}
