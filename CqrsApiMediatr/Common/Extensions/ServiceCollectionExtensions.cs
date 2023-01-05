using System.Reflection;
using AutoMapper;
using CqrsApiMediatr.Infra.Repositories;
using CqrsApiMediatr.Infra.Repositories.Interfaces;
using MediatR;

namespace CqrsApiMediatr.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            /* Handlers */
            services.AddMediatR(Assembly.GetExecutingAssembly());

            /* Repositories */
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config => config.AddMaps(Assembly.GetEntryAssembly()));

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
        }
    }
}