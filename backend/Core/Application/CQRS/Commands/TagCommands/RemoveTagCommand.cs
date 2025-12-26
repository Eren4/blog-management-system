using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.TagCommands
{
    public class RemoveTagCommand
    {
        public int Id { get; set; }
        public RemoveTagCommand(int id)
        {
            Id = id;
        }   
    }
}
