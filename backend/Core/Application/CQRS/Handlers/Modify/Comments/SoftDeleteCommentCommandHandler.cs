using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.CommentCommands;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Modify.Comments
{
    public class SoftDeleteCommentCommandHandler
    {
        private ICommentRepository _repository;

        public SoftDeleteCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comment> Handle(SoftDeleteCommentCommand command)
        {
            Comment value = await _repository.GetByIdAsync(command.Id);

            if(value == null)
            {
                return null;
            }

            if (value.IsActive == false)
            {
                throw new Exception("Yorum zaten pasif");
            }

            value.Deactivate();

            await _repository.SaveChangesAsync();

            return null;
        }
    }
}
