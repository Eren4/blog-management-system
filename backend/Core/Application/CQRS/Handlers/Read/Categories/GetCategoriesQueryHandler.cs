

using Application.CQRS.Results.CategoryResults;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Categories
{
    public class GetCategoriesQueryHandler
    {
        private readonly ICategoryRepository _repository;

        public GetCategoriesQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoriesQueryResult>> Handle()
        {
            List<Category> values = await _repository.GetAllAsync();

            return values.Select(x => new GetCategoriesQueryResult
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
        }
    }
}
