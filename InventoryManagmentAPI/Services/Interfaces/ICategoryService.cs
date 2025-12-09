using InventoryManagmentAPI.DTOs.CategoryDTO;
using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.Entities;
using MiniLibraryAPI.Responses;

namespace InventoryManagmentAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<Response<ResponseGetList<List<Category>>>> GetCategories(CategoryFilter filter);
    Task<Response<Category>> GetById(long categoryId);
    Task<Response<string>> CreateCategory(AddCategoryDto category);
    Task<Response<string>> UpdateCategory(Category category);
    Task<Response<string>> DeleteCategory(long categoryId);
    
}