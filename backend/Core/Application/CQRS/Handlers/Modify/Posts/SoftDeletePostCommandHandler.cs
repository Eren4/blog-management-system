using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.PostCommands;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Modify.Posts
{
    public class SoftDeletePostCommandHandler
    {
        private IPostRepository _repository;

        public SoftDeletePostCommandHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> Handle(SoftDeletePostCommand command)
        {
            Post value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            if(value.IsActive == false)
            {
                throw new Exception("Gönderi zaten pasif");
            }

            value.Deactivate();

            await _repository.SaveChangesAsync();

            return value;
        }
    }
}
