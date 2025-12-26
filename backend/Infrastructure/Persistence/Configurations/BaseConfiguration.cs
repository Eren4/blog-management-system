using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T: BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

        }
    }
}
