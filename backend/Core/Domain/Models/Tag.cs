using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }

        // Relational properties
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
