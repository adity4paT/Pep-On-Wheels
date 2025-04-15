using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.ProductImage;

public class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        CreateMap<ProductImage, ProductImageReadDTO>();
        CreateMap<ProductImageCreateDTO, ProductImage>();
    }
}
