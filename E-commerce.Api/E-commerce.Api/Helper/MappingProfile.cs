using AutoMapper;
using E_commerce.Application.Dtos;
using E_commerce.Domain.Entities;

namespace E_commerce.Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
           .ForMember(dest => dest.Image, opt => opt.MapFrom<ImageResolver>())
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src=>src.CategoryId))
           .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }

    }
}
