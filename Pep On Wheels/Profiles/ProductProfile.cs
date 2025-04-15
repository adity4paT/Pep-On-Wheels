using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.Product;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductReadDTO>();
        CreateMap<ProductCreateDTO, Product>();
        CreateMap<ProductUpdateDTO, Product>();
    }
}
