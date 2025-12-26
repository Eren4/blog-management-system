using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace Application.CQRS.Commands.PostCommands
{
    public class CreatePostCommand
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
    }
}
