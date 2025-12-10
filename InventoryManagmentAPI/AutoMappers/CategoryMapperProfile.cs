using AutoMapper;
using InventoryManagmentAPI.DTOs.CategoryDTO;
using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.AutoMappers;

public class CategoryMapperProfile:Profile
{

    public CategoryMapperProfile()
    {
        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
    
}