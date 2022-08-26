using Application.Common.CommenModel;
using Application.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Managers
{
    public interface ICategoryManager
    {
        ServiceResponse GetCategories();

        ServiceResponse SaveCategories(CategoryModel categoryModel);

        ServiceResponse GetSubCategory();

        ServiceResponse SaveGetSubCategory(SubCategoryModel  subCategoryModel);
    }
}
