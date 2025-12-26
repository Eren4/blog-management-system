using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.PostQueries
{
    public class GetPostByIdQuery
    {
        public int Id { get; set; }

        public GetPostByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
