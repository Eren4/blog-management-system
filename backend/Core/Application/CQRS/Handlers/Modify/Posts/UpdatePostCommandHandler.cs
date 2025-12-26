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
    public class UpdatePostCommandHandler
    {
        private IPostRepository _repository;

        public UpdatePostCommandHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> Handle(UpdatePostCommand command)
        {
            Post value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            value.Title = command.Title;
            value.Content = command.Content;
            value.Excerpt = command.Excerpt;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();

            return value;
        }
    }
}
