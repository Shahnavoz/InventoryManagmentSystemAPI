using AutoMapper;
using InventoryManagmentAPI.DTOs.SupplyDTO;
using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.AutoMappers;

public class SupplyMapperProfile:Profile
{
    public SupplyMapperProfile()
    {
        CreateMap<AddSupplyDto, Supply>();
        CreateMap<UpdateSupplyDto, Supply>();
    }
    
}