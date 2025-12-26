using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.CommentCommands
{
    public class RemoveCommentCommand
    {
        public int Id { get; set; }
        public RemoveCommentCommand(int id)
        {
            Id = id;
        }
    }
}
