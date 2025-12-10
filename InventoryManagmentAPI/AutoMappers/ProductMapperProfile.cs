using AutoMapper;
using InventoryManagmentAPI.DTOs.ProductDTO;
using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.AutoMappers;

public class ProductMapperProfile:Profile
{
    public ProductMapperProfile()
    {
        CreateMap<AddProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
    }
    
}