using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace Application.CQRS.Commands.CommentCommands
{
    public class UpdateCommentCommand
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public ApproveState ApproveState { get; set; }
    }
}
