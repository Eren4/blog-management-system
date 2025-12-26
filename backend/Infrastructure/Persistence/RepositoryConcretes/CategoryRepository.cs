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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly MyContext _context;

        public CategoryRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            return _context.Categories.AnyAsync(c => c.CategoryName.ToLower().Equals(name.ToLower()));
        }
    }
}
