using InventoryManagmentAPI.DTOs.CategoryDTO;
using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.Entities;
using InventoryManagmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService):ControllerBase
{
    [HttpGet("GetAllCategories")]
    public async Task<Response<ResponseGetList<List<Category>>>> GetCategories([FromQuery]CategoryFilter filter)
    {
        return await categoryService.GetCategories(filter);
    }

    [HttpGet]
    public async Task<Response<Category>> GetCategory(long id)
    {
        return await categoryService.GetById(id);
    }

    [HttpPost]
    public async Task<Response<Category>> CreateCategory(AddCategoryDto categoryDto)
    {
        return await categoryService.CreateCategory(categoryDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCategory(UpdateCategoryDto categorytDto)
    {
        return await categoryService.UpdateCategory(categorytDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteCategory(long id)
    {
        return await categoryService.DeleteCategory(id);
    }
    
    
}