using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.CategoryCommands
{
    public class SoftDeleteCategoryCommand
    {
        public int Id { get; set; }

        public SoftDeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
