using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.RepositoryInterfaces;
using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace Application.Validators.Category
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        public CreateCategoryCommandValidator(ICategoryRepository repository)
        {
            _repository = repository;

            RuleFor(c => c.CategoryName)
                .MustAsync(BeUniqueName).WithMessage("Kategori ismi daha önceden mevcut");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return !await _repository.ExistsByNameAsync(name);
        }
    }
}
