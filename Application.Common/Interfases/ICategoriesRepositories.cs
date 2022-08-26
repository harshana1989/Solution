using Application.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfases
{
    public interface ICategoriesRepositories
    {
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel> Save(CategoryModel categoryModel);
        Task<List<SubCategoryModel>> GetSubCategories();
        Task<SubCategoryModel> SaveSubcatagory(SubCategoryModel subCategoryModel);
    }
}
