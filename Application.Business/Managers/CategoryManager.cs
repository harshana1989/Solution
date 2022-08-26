using Application.Common.CommenModel;
using Application.Common.Entities;
using Application.Common.Interfases;
using Application.Common.Managers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Managers
{
    public class CategoryManager : ICategoryManager
    {

        private readonly ICategoriesRepositories categoryRepositories;

        private readonly IMapper<Object, ServiceResponse> serviceResponseMapper;

        private readonly IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper;

        private readonly IConfiguration configuration;
       
        public CategoryManager(IMapper<Object, ServiceResponse> serviceResponseMapper,
                   ICategoriesRepositories categoryRepositories, IConfiguration configuration)
        {
            this.serviceResponseMapper = serviceResponseMapper;
            this.categoryRepositories = categoryRepositories;
            this.configuration = configuration;
        }

        public ServiceResponse GetCategories()
        {
            try
            {
                var result = categoryRepositories.GetCategories();
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse GetSubCategory()
        {
            try
            {
                var result = categoryRepositories.GetSubCategories();
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse SaveCategories(CategoryModel categoryModel)
        {
            try
            {
                var result = categoryRepositories.Save(categoryModel);
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse SaveGetSubCategory(SubCategoryModel subCategoryModel)
        {
            try
            {
                var result = categoryRepositories.SaveSubcatagory(subCategoryModel);
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
