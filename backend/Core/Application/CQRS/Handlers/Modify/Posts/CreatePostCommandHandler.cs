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
    public class CreatePostCommandHandler
    {
        private IPostRepository _repository;

        public CreatePostCommandHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePostCommand command)
        {
            await _repository.CreateAsync(new Post
            {
                Title = command.Title,
                Content = command.Content,
                Excerpt = command.Excerpt,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
