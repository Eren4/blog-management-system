using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.TagCommands
{
    public class CreateTagCommand
    {
        public string TagName { get; set; }
    }
}
