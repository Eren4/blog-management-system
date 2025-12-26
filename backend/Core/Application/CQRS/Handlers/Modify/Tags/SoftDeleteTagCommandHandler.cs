using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.TagCommands;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Modify.Tags
{
    public class SoftDeleteTagCommandHandler
    {
        private ITagRepository _repository;

        public SoftDeleteTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tag> Handle(SoftDeleteTagCommand command)
        {
            Tag value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            if(value.IsActive == false)
            {
                throw new Exception("Etiket zaten pasif");
            }

            value.Deactivate();

            await _repository.SaveChangesAsync();

            return value;
        }
    }
}
