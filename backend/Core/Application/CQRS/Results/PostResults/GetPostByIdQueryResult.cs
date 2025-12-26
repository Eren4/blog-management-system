using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace Application.CQRS.Results.PostResults
{
    public class GetPostByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public PublishState PublishState { get; set; }
    }
}
