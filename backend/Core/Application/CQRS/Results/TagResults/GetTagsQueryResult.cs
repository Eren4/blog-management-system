using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Results.TagResults
{
    public class GetTagsQueryResult
    {
        public int Id { get; set; }
        public string TagName { get; set; }
    }
}
