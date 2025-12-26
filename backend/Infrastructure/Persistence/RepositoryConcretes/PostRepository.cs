using Contract.RepositoryInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryConcretes
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(MyContext context) : base(context)
        {
        }
    }
}
