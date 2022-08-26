using Application.Common.Entities;
using Application.Common.Interfases;
using Application.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Repositories
{
    public class CategoryRepositories : ICategoriesRepositories
    {
        private readonly ApplicationDBContext entities;

        private readonly IEntityMapper entityMapper;

        public CategoryRepositories(IEntityMapper entityMapper, ApplicationDBContext entities)
        {
            this.entities = entities;
            this.entityMapper = entityMapper;
        }
        public async Task<List<CategoryModel>> GetCategories()
        {
            try
            {
                var categories = this.entities.Categories.Where(z => z.IsActive == true).AsNoTracking().ToList();
                return this.entityMapper.Map<List<Categories>, List<CategoryModel>>(categories);
            }
            catch (Exception)
            {

                throw;
            }
            // having small issue with async need more time to investigate 
            //try
            //{

            //   // var categoryList = await entities.Categories.Where(a=>a.Id==1).AsNoTracking().ToListAsync();
            //   //return this.entityMapper.Map<List<Categories>, List<CategoryModel>>(categoryList);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public async Task<CategoryModel> Save(CategoryModel categoryModel)
        {
            try
            {
                var category = entityMapper.Map<CategoryModel, Categories>(categoryModel);
                if (categoryModel.Id != 0)
                {
                    var categoryItem = this.entities.Categories.FirstOrDefault(a => a.Id == category.Id);
                    if (categoryItem != null)
                    {
                        categoryItem.Name = category.Name;
                        categoryItem.IsActive = category.IsActive;
                        this.entities.SaveChanges();
                    }
                }
                else
                {
                    this.entities.Categories.Add(category);
                    this.entities.SaveChanges();
                }
                return entityMapper.Map<Categories, CategoryModel>(category);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<SubCategoryModel>> GetSubCategories()
        {
            try
            {
                var subcategory = this.entities.Subcategory.Where(z => z.IsActive == true).AsNoTracking().ToList();
                return this.entityMapper.Map<List<Subcategory>, List<SubCategoryModel>>(subcategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SubCategoryModel> SaveSubcatagory(SubCategoryModel subCategoryModel)
        {
            try
            {
                var subcategory = entityMapper.Map<SubCategoryModel, Subcategory>(subCategoryModel);
                if (subcategory.Id != 0)
                {
                    var subcategoryItem = this.entities.Subcategory.FirstOrDefault(a => a.Id == subcategory.Id);
                    if (subcategoryItem != null)
                    {
                        subcategoryItem.Name = subcategory.Name;
                        subcategoryItem.Description = subcategory.Description;
                        subcategoryItem.Price = subcategory.Price;
                        subcategoryItem.AvalabalOptionsCount = subcategory.AvalabalOptionsCount;
                        subcategoryItem.CatagoryId = subcategory.CatagoryId;
                        subcategoryItem.IsActive = subcategory.IsActive;
                        this.entities.SaveChanges();
                    }
                }
                else
                {
                    this.entities.Subcategory.Add(subcategory);
                    this.entities.SaveChanges();
                }
                return entityMapper.Map<Subcategory, SubCategoryModel>(subcategory);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
