using System.Net;
using AutoMapper;
using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.DTOs.SupplyDTO;
using InventoryManagmentAPI.Entities;
using InventoryManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentAPI.Services;

public class SupplyService(ApplicationDbContext context,IMapper mapper):ISupplyService
{
    public async Task<Response<ResponseGetList<List<Supply>>>> GetSupplies(SupplyFilter filter)
    {
        var query = context.Supplies.AsQueryable();
        if(filter.Id != null)
        {
            query = query.Where(x => x.Id == filter.Id);
        }

        if (filter.SupplyCount != null)
        {
            query = query.Where(x => x.SupplyCount == filter.SupplyCount);
        }
        
        
        return new Response<ResponseGetList<List<Supply>>>(
            HttpStatusCode.OK,
            "Successfuly!",
            new ResponseGetList<List<Supply>>
            {
                Payload = await query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync(),
                Page = filter.PageNumber,
                Size = filter.PageSize,
                TotalRecords = await query.CountAsync()
            }
        );
    }

    public async Task<Response<Supply>> GetSupplyById(long Id)
    {
        var supply = await context.Supplies.FindAsync(Id);
        return supply==null ? new Response<Supply>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<Supply>(HttpStatusCode.OK,"Found Successfully!",supply);
    }

    public async Task<Response<Supply>> CreateSupply(AddSupplyDto supplyDto)
    {
        var supply = mapper.Map<Supply>(supplyDto);
        context.Supplies.Add(supply);
        await context.SaveChangesAsync();
        return supply==null ? new Response<Supply>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<Supply>(HttpStatusCode.OK,"Successfully!",supply);
    }

    public async Task<Response<string>> UpdateSupply(UpdateSupplyDto supplyDto)
    {
        var supply=await GetSupplyById(supplyDto.Id);
        if (supply == null)
        {
            return new Response<string>(HttpStatusCode.NotFound,"Supply not found");
        }
        supply.Data.SupplyCount = supplyDto.SupplyCount;
        var result = context.Supplies.Update(supply.Data);
        context.SaveChanges();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Successfully!");
    }

    public async Task<Response<string>> DeleteSupply(long Id)
    {
        var supply = context.Supplies.Where(s => s.Id == Id).ExecuteDeleteAsync();
        return supply==null ? new Response<string>(HttpStatusCode.NotFound,"Supply not found")
            : new Response<string>(HttpStatusCode.OK,"Successfully!");
    }
}