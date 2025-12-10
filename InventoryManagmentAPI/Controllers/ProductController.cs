using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.DTOs.ProductDTO;
using InventoryManagmentAPI.Entities;
using InventoryManagmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentAPI.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController(IProductService  productService):ControllerBase
{
    [HttpGet("GetAllProducts")]
    public async Task<Response<ResponseGetList<List<Product>>>> GetAllProducts([FromQuery] ProductFilter filter)
    {
        return await productService.GetProducts(filter);
    }

    [HttpGet]
    public async Task<Response<Product>> GetProductById(long id)
    {
        return await productService.GetProductById(id);
    }

    [HttpPost]
    public async Task<Response<string>> AddProduct(AddProductDto productDto)
    {
        return await productService.CreateProduct(productDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateProduct(UpdateProductDto productDto)
    {
        return await productService.UpdateProduct(productDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteProduct(long id)
    {
        return await productService.DeleteProduct(id);
    }
}