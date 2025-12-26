using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment : BaseEntity
    {
        public string AuthorName { get; set; }
        public string Text { get; set; } // cannot be empty
        public ApproveState ApproveState { get; set; }
    }
}
