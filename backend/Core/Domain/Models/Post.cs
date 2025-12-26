using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public PublishState PublishState { get; set; }

        // Relational properties
        public ICollection<Category> Categories;
        public ICollection<Tag> Tags;
        public ICollection<Comment> Comments;
    }
}
