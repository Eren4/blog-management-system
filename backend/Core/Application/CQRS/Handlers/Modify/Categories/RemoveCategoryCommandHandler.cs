using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.RepositoryInterfaces;
using Domain.Models;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace Application.CQRS.Handlers.Modify.Categories
{
    public class RemoveCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(RemoveCategoryCommand command)
        {
            Category value = await _repository.GetByIdAsync(command.Id);
            
            if (value == null)
            {
                return null;
            }

            await _repository.DeleteAsync(value);

            return value;
        }
    }
}
