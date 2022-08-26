using Application.Business.Managers;
using Application.Common.CommenModel;
using Application.Common.Interfases;
using Application.Common.Managers;
using Application.Common.Mappers;
using Application.Data.Mappers;
using Application.Data.Repositories;
using Application.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddDbContext<ApplicationDBContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion


            services.AddScoped<IEntityMapper, EntityMapper>();
            services.AddScoped<IErrorMessages, ErrorMessages>();

            services.AddScoped<ICategoriesRepositories, CategoryRepositories>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            #region Mappers
            services.AddSingleton<IMapper<IList<Message>, ServiceResponse>, ServiceErrorMapper>();
            services.AddSingleton<IMapper<object, ServiceResponse>, ServiceResponseMapper>();
            services.AddSingleton<IMapper<(IList<Message>, object), ServiceResponse>, ServiceErrorWithReturnMapper>();
            #endregion

            services.AddLogging();
            return services;
        }
    }
}