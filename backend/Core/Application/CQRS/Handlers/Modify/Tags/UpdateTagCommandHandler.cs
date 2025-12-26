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
    public class UpdateTagCommandHandler
    {
        private ITagRepository _repository;

        public UpdateTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tag> Handle(UpdateTagCommand command)
        {
            Tag value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            value.TagName = command.TagName;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();

            return value;
        }
    }
}
