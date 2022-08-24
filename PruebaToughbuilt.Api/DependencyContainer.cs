using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaToughbuilt.Business;
using PruebaToughbuilt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Api
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencyPruebaToughbuilt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDependencyBusiness();
            services.AddDependencyData(configuration);
            return services;
        }
    }
}
