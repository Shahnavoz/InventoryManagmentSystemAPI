using System.Net;
using AutoMapper;
using InventoryManagmentAPI.DTOs.CategoryDTO;
using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.Entities;
using InventoryManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniLibraryAPI.Responses;

namespace InventoryManagmentAPI.Services;

public class CategoryService(ApplicationDbContext context,IMapper mapper):ICategoryService
{
    public async Task<Response<ResponseGetList<List<Category>>>> GetCategories(CategoryFilter filter)
    {
       var query = context.Categories.AsQueryable();

       if (filter.Id != null)
       {
           query = query.Where(x => x.Id == filter.Id);
       }

       if (!string.IsNullOrEmpty(filter.Name))
       {
           query = query.Where(x => x.Name.Contains(filter.Name));
       }

       if (!string.IsNullOrEmpty(filter.Description))
       {
           query = query.Where(x => x.Description.Contains(filter.Description));
       }
       
       
       return new Response<ResponseGetList<List<Category>>>(
           HttpStatusCode.OK,
           "Successfuly!",
           new ResponseGetList<List<Category>>
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

    public Task<Response<Category>> GetById(long categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> CreateCategory(AddCategoryDto category)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> DeleteCategory(long categoryId)
    {
        throw new NotImplementedException();
    }
}