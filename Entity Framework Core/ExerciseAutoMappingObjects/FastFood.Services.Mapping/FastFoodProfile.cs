using AutoMapper;
using FastFood.Models;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Positions;

namespace FastFood.Services.Mapping
{
    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            //Categories
            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name,
                    y => y.MapFrom(x => x.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Item
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(d => d.CategoryId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CategoryName,
                    opt => opt.MapFrom(src => src.Name));

            this.CreateMap<CreateItemInputModel, Item>();
            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(d=> d.Category,
                    opt => opt.MapFrom(src=> src.Category.Name));
        }
    }
}
