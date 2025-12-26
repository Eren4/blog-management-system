using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.PostCommands
{
    public class RemovePostCommand
    {
        public int Id { get; set; }
        public RemovePostCommand(int id)
        {
            Id = id;
        }
    }
}
