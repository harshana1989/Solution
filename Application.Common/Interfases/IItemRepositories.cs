using Application.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfases
{
    public interface IItemRepositories
    {
        Task<ItemModel> GetItemById(int id);
        Task<List<ItemModel>> GetItemByName(string name);
        Task<ItemModel> Save(ItemModel itemModel);
    }
}
