using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Results.PostResults;
using Application.CQRS.Results.TagResults;
using Contract.RepositoryInterfaces;
using Domain.Models;

namespace Application.CQRS.Handlers.Read.Tags
{
    public class GetTagsQueryHandler
    {
        private ITagRepository _repository;

        public GetTagsQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagsQueryResult>> Handle()
        {
            List<Tag> values = await _repository.GetAllAsync();

            return values.Select(x => new GetTagsQueryResult
            {
                TagName = x.TagName
            }).ToList();
        }
    }
}
