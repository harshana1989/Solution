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
    public class ItemRepositories : IItemRepositories
    {
        private readonly ApplicationDBContext entities;

        private readonly IEntityMapper entityMapper;

        public ItemRepositories(IEntityMapper entityMapper, ApplicationDBContext entities)
        {
            this.entities = entities;
            this.entityMapper = entityMapper;
        }
        public async Task<ItemModel> GetItemById(int id)
        {
            try
            {
                var item = this.entities.Items.Where(z => z.IsActive == true && z.Id==id).AsNoTracking().FirstOrDefault();
                return this.entityMapper.Map<Items, ItemModel>(item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ItemModel>> GetItemByName(string name)
        {
            try
            {
                var items = this.entities.Items.Where(z => z.IsActive == true && z.Title.Contains(name)).AsNoTracking().ToList();
                return this.entityMapper.Map<List<Items>, List<ItemModel>>(items);
            }

            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ItemModel> Save(ItemModel itemModel)
        {
            try
            {
                var item = entityMapper.Map<ItemModel, Items>(itemModel);
                if (item.Id != 0)
                {
                    var resultItem = this.entities.Items.FirstOrDefault(a => a.Id == item.Id);
                    if (resultItem != null)
                    {
                        resultItem.Description = item.Description;
                        resultItem.Price = item.Price;
                        resultItem.Title = item.Title;
                        resultItem.SubCatId = item.SubCatId;
                        resultItem.IsActive = item.IsActive;
                        this.entities.SaveChanges();
                    }
                }
                else
                {
                    this.entities.Items.Add(item);
                    this.entities.SaveChanges();
                }
                return entityMapper.Map<Items, ItemModel>(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
