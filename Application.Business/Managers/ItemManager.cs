using Application.Common.CommenModel;
using Application.Common.Entities;
using Application.Common.Interfases;
using Application.Common.Managers;
using Application.Common.Mappers;
using Application.Data.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepositories itemRepositories;

        private readonly IMapper<Object, ServiceResponse> serviceResponseMapper;

        private readonly IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper;

        private readonly IConfiguration configuration;

        public ItemManager(IMapper<Object, ServiceResponse> serviceResponseMapper,
                   IItemRepositories itemRepositories, IConfiguration configuration)
        {
            this.serviceResponseMapper = serviceResponseMapper;
            this.itemRepositories = itemRepositories;
            this.configuration = configuration;
        }
        public ServiceResponse GetItemById(int id)
        {
            try
            {
                var result = itemRepositories.GetItemById(id);
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse GetItemByName(string name)
        {
            try
            {
                var result = itemRepositories.GetItemByName(name);
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResponse Save(ItemModel itemModel)
        {
            try
            {
                var result = itemRepositories.Save(itemModel);
                return serviceResponseMapper.Map(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
