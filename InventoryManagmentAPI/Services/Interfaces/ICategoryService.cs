using InventoryManagmentAPI.DTOs.CategoryDTO;
using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<Response<ResponseGetList<List<Category>>>> GetCategories(CategoryFilter filter);
    Task<Response<Category>> GetById(long categoryId);
    Task<Response<Category>> CreateCategory(AddCategoryDto category);
    Task<Response<string>> UpdateCategory(UpdateCategoryDto category);
    Task<Response<string>> DeleteCategory(long categoryId);
    
}