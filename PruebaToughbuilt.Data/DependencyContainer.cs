using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaToughbuilt.Data.Blob;
using PruebaToughbuilt.Data.Data;
using PruebaToughbuilt.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Data
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencyData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDBPruebaToughbuilt>(
            options => options.UseSqlServer(configuration.GetConnectionString("ConnectionMain")));

            services.AddScoped(x => new BlobServiceClient(
                configuration.GetConnectionString("AzureBlobStorage")));

            services.AddScoped<IProductData, ProductData>();
            services.AddScoped<IImageData, ImageData>();
            services.AddScoped<ICategoryData, CategoryData>();
            services.AddScoped<IBlobData, BlobData>();
            services.AddScoped<ICharacteristicsData, CharacteristicsData>();

            return services;
        }
    }
}
