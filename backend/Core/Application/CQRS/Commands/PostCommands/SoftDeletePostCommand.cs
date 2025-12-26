using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.PostCommands
{
    public class SoftDeletePostCommand
    {
        public int Id { get; set; }

        public SoftDeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
