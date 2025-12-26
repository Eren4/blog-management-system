using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolvers
{
    public static class CommandResultMapperResolver
    {
        public static void AddCommandResultMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandResultMappingProfile));
        }
    }
}
