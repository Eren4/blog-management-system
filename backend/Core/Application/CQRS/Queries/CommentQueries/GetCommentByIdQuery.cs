using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.CommentQueries
{
    public class GetCommentByIdQuery
    {
        public int Id { get; set; }

        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
