using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.CategoryCommands;
using Contract.RepositoryInterfaces;
using Domain.Models;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace Application.CQRS.Handlers.Modify.Categories
{
    public class SoftDeleteCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public SoftDeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(SoftDeleteCategoryCommand command)
        {
            Category value = await _repository.GetByIdAsync(command.Id);

            if(value == null)
            {
                return null;
            }

            if (value.IsActive == false)
            {
                throw new Exception("Kategori zaten pasif");
            }

            value.Deactivate();

            await _repository.SaveChangesAsync();

            return value;
        }
    }
}
