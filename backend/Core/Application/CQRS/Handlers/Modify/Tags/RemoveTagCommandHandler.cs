using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.PostCommands;
using Application.CQRS.Commands.TagCommands;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Modify.Tags
{
    public class RemoveTagCommandHandler
    {
        private ITagRepository _repository;

        public RemoveTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tag> Handle(RemoveTagCommand command)
        {
            Tag value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            await _repository.DeleteAsync(value);

            return value;
        }
    }
}
