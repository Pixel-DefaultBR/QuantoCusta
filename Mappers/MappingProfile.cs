using AutoMapper;
using QuantoCusta.Models;
using QuantoCusta.DTOS;

namespace QuantoCusta.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, CreateProductDto>()
                .ReverseMap();
            CreateMap<ProductModel, UpdateProductDto>()
                .ReverseMap();
            CreateMap<ProductModel, ProductModel>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
            CreateMap<CreateProductDto, ProductModel>();
            CreateMap<ProductModel, ProductResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Cattegory Mapping
            CreateMap<CategoryModel, CategoryResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<CategoryModel, CreateCategoryDto>()
                .ReverseMap();
            CreateMap<CategoryModel, UpdateCategoryDto>()
                .ReverseMap();
        }
    }
}
