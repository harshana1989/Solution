using Application.Common.CommenModel;
using Application.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Managers
{
    public interface IItemManager
    {
        ServiceResponse GetItemById(int id);
        ServiceResponse GetItemByName(string name);
        ServiceResponse Save(ItemModel itemModel);
       
    }
}
