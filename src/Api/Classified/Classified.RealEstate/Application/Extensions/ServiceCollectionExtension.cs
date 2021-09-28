using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Classified.RealEstate.Application.Services;
using Classified.RealEstate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Classified.RealEstate.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRealEstate(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<RealEstateDataContext>();
            services.AddScoped<IBuilderService, BuilderService>();

        }
    }
}
