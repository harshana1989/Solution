using Application.Business.Managers;
using Application.Common.CommenModel;
using Application.Common.Entities;
using Application.Common.Interfases;
using Application.Common.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    public class ItemController : Controller
    {
        private IItemManager itemManager;

        private readonly IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper;

        private readonly IErrorMessages errorMessages;

        private readonly ILogger logger;
        public ItemController(IItemManager itemManager
            , IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper
            , IErrorMessages errorMessages, ILogger<CategoryController> logger)
        {
            this.itemManager = itemManager;
            this.serviceResponseErrorMapper = serviceResponseErrorMapper;
            this.errorMessages = errorMessages;
            this.logger = logger;

        }
        [HttpGet("GetByID")]
        public ServiceResponse GetByID(int id)
        {
            try
            {
                return itemManager.GetItemById(id);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }
        [HttpGet("GetByName")]
        public ServiceResponse GetByName(string name)
        {
            try
            {
                return itemManager.GetItemByName(name);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }

        [HttpPost("Save")]
        public ServiceResponse Save(ItemModel itemModel)
        {
            try
            {
                return itemManager.Save(itemModel);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }
    }
}
