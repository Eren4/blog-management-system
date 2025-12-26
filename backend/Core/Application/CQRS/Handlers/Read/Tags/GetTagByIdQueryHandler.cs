using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Queries.TagQueries;
using Application.CQRS.Results.TagResults;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Read.Tags
{
    public class GetTagByIdQueryHandler
    {
        private ITagRepository _repository;

        public GetTagByIdQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery query)
        {
            Tag value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
                return null;

            return new GetTagByIdQueryResult()
            {
                Id = value.Id,
                TagName = value.TagName
            };
        }
    }
}
