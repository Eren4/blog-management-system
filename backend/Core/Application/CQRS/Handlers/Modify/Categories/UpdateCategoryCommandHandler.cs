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
    public class UpdateCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(UpdateCategoryCommand command)
        {
            Category value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                return null;
            }

            value.CategoryName = command.CategoryName;
            value.Description = command.Description;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();

            return value;
        }
    }
}
