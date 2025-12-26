using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.RepositoryInterfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}
