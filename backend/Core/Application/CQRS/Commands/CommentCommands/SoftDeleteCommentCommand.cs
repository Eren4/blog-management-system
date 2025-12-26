using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.CommentCommands
{
    public class SoftDeleteCommentCommand
    {
        public int Id { get; set; }

        public SoftDeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
