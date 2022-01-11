using AutoMapper;
using Product.Application.Dto;
using Product.Domain.Entity;

namespace Product.Application.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<AddCategoryDto, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}