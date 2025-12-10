using System.Net;
using AutoMapper;
using InventoryManagmentAPI.DTOs.CategoryDTO;
using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.Entities;
using InventoryManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Response<Category>> GetById(long categoryId)
    {
        var category=await context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
        return category == null ? new Response<Category>(HttpStatusCode.InternalServerError,"Server Error!")
                : new Response<Category>(HttpStatusCode.OK, "Success!", category);

    }

    public async Task<Response<Category>> CreateCategory(AddCategoryDto categoryDto)
    {
        var category=mapper.Map<Category>(categoryDto);
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category ==null  ? new Response<Category>(HttpStatusCode.InternalServerError, "Server Error!")
                :new Response<Category>(HttpStatusCode.OK, "Success!",category);
    }

    public async Task<Response<string>> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        var category=await GetById(categoryDto.CategoryId);
        if(category == null) return new Response<string>(HttpStatusCode.InternalServerError, "Server Error!");
        category.Data.Name = categoryDto.Name;
        context.Entry(category).CurrentValues.SetValues(categoryDto);
        await context.SaveChangesAsync();
        return category ==null? new Response<string>(HttpStatusCode.InternalServerError, "Server Error!")
            :new Response<string>(HttpStatusCode.OK, "Success!");
    }

    public async Task<Response<string>> DeleteCategory(long categoryId)
    {
        var category = context.Categories.Where(c => c.Id == categoryId).ExecuteDeleteAsync();
        return category==null? new Response<string>(HttpStatusCode.InternalServerError, "Server Error!")
            :new Response<string>(HttpStatusCode.OK, "Success!");
    }
}