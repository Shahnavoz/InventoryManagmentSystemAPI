using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.DTOs.SupplyDTO;
using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.Services.Interfaces;

public interface ISupplyService
{
    Task<Response<ResponseGetList<List<Supply>>>> GetSupplies(SupplyFilter filter);
    Task<Response<Supply>> GetSupplyById(long Id);
    Task<Response<Supply>> CreateSupply(AddSupplyDto supply);
    Task<Response<string>> UpdateSupply(UpdateSupplyDto supply);
    Task<Response<string>> DeleteSupply(long Id);
}