using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Results.CategoryResults
{
    public class GetCategoriesQueryResult
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
