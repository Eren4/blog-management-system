using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.CommentCommands;
using Application.CQRS.Commands.PostCommands;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Modify.Posts
{
    public class RemovePostCommandHandler
    {
        private IPostRepository _repository;

        public RemovePostCommandHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> Handle(RemovePostCommand command)
        {
            Post value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            await _repository.DeleteAsync(value);

            return value;
        }
    }
}
