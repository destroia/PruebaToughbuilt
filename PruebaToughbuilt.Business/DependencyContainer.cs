using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaToughbuilt.Business.Business;
using PruebaToughbuilt.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencyBusiness(this IServiceCollection services)
        {
            services.AddTransient<IImageBI, BIImage>();
            services.AddTransient<IProductBI, BIProduct>();
            services.AddTransient<ICategoryBI, BICategory>();
            services.AddTransient<ICharacteristicBI, BICharacteristic>();

            return services;
        }
    }
}
