using Application.CQRS.Results.CategoryResults;
using Contract.RepositoryInterfaces;
using Domain.Models;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Categories
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {

            Category value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
                return null;

            return new GetCategoryByIdQueryResult
            {
                CategoryName = value.CategoryName,
                Description = value.Description,
                Id = value.Id
            };
        }
    }
}
