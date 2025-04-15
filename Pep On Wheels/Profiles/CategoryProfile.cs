using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.Category;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryReadDTO>();
        CreateMap<CategoryCreateDTO, Category>();
        CreateMap<CategoryUpdateDTO, Category>();
    }
}
