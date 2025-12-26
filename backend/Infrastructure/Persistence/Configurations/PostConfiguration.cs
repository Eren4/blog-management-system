using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class PostConfiguration : BaseConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Content)
                .IsRequired();
        }
    }
}
