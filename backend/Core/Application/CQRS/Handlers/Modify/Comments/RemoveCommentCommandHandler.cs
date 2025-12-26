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
    public class RemoveCommentCommandHandler
    {
        private ICommentRepository _repository;

        public RemoveCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comment> Handle(RemoveCommentCommand command)
        {
            Comment value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            await _repository.DeleteAsync(value);

            return value;
        }
    }
}
