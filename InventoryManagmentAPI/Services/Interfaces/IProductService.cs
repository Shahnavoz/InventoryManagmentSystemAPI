using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.DTOs.ProductDTO;
using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.Services.Interfaces;

public interface IProductService
{
    Task<Response<ResponseGetList<List<Product>>>>  GetProducts(ProductFilter filter);
    Task<Response<Product>>  GetProductById(long id);
    Task<Response<string>> CreateProduct(AddProductDto productDto);
    Task<Response<string>> UpdateProduct(UpdateProductDto productDto);
    Task<Response<string>> DeleteProduct(long id);
    
}