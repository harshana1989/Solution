using Application.Common.Entities;
using Application.Common.Interfases;
using Application.DataContext;
using AutoMapper;

namespace Application.Data.Mappers
{
    public class EntityMapper : IEntityMapper
    {
        private MapperConfiguration _config;
        private IMapper _mapper;

        public EntityMapper()
        {
            Configure();
            Create();

        }
        private void Configure()
        {
            _config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Categories, CategoryModel>()
                //.ForMember(t => t.Id, m => m.MapFrom(u => u.Id))
                //.ForMember(t => t.Name, m => m.MapFrom(u => u.Name))
                //.ForMember(t => t.IsActive, m => m.MapFrom(u => u.IsActive));
                cfg.CreateMap<CategoryModel, Categories>();
                cfg.CreateMap<Categories, CategoryModel>();

                cfg.CreateMap<SubCategoryModel, Subcategory>();
                cfg.CreateMap<Subcategory, SubCategoryModel>();

                cfg.CreateMap<ItemModel, Items>();
                cfg.CreateMap<Items, ItemModel>();
            });
        }
        private void Create()
        {
            _mapper = _config.CreateMapper();
        }
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

    }
}
