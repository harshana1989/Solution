using Application.Common.CommenModel;
using Application.Common.Entities;
using Application.Common.Interfases;
using Application.Common.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryManager categoryManager;

        private readonly IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper;

        private readonly IErrorMessages errorMessages;

        private readonly ILogger logger;


        public CategoryController(ICategoryManager categoryManager
            , IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper
            , IErrorMessages errorMessages, ILogger<CategoryController> logger)
        {
            this.categoryManager = categoryManager;
            this.serviceResponseErrorMapper = serviceResponseErrorMapper;
            this.errorMessages = errorMessages;
            this.logger = logger;
        }
        [HttpGet("GetCategory")]
        public ServiceResponse GetCategory()
        {
            try
            {
                return categoryManager.GetCategories();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }

        [HttpGet("GetSubCategory")]
        public ServiceResponse GetSubCategory()
        {
            try
            {
                return categoryManager.GetSubCategory();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }
        [HttpPost("SaveSubCategory")]
        public ServiceResponse SaveSubCategory(SubCategoryModel subCategoryModel)
        {
            try
            {
                return categoryManager.SaveGetSubCategory(subCategoryModel);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                return serviceResponseErrorMapper.Map(new List<Message> { errorMessages.GetServiceErrorMessage("") });
            }
        }
    }
}
