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
    public class CreateTagCommandHandler
    {
        private ITagRepository _repository;

        public CreateTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCommand command)
        {
            await _repository.CreateAsync(new Tag
            {
                TagName = command.TagName,
                CreatedDate = DateTime.Now
            });
        }
    }
}
