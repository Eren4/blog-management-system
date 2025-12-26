using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.TagCommands
{
    public class SoftDeleteTagCommand
    {
        public int Id { get; set; }

        public SoftDeleteTagCommand(int id)
        {
            Id = id;
        }
    }
}
