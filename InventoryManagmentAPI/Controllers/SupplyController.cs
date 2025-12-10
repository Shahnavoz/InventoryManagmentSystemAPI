using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.DTOs.SupplyDTO;
using InventoryManagmentAPI.Entities;
using InventoryManagmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class SupplyController(ISupplyService supplyService):ControllerBase
{
    [HttpGet("GetSupplies")]
    public async Task<Response<ResponseGetList<List<Supply>>>> GetSupplies(SupplyFilter filter)
    {
        return await supplyService.GetSupplies(filter);
    }

    [HttpGet]
    public async Task<Response<Supply>> GetSupply(long Id)
    {
        return await supplyService.GetSupplyById(Id);
    }

    [HttpPost]
    public async Task<Response<Supply>> CreateSupply(AddSupplyDto supply)
    {
        return await supplyService.CreateSupply(supply);
        
    }

    [HttpPut]
    public async Task<Response<string>> UpdateSupply(UpdateSupplyDto supply)
    {
        return await supplyService.UpdateSupply(supply);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteSupply(long Id)
    {
        return await supplyService.DeleteSupply(Id);
    }
}