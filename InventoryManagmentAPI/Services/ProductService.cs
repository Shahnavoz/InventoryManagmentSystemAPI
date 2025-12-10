using System.Net;
using AutoMapper;
using InventoryManagmentAPI.DTOs.Filters;
using InventoryManagmentAPI.DTOs.ProductDTO;
using InventoryManagmentAPI.Entities;
using InventoryManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentAPI.Services;

public class ProductService(ApplicationDbContext context,IMapper mapper):IProductService
{
    public async Task<Response<ResponseGetList<List<Product>>>> GetProducts(ProductFilter  filter)
    {
        var query = context.Products.AsQueryable();
        if (filter.Id != null)
        {
            query = query.Where(p => p.Id == filter.Id);
        }

        if (filter.Name != null)
        {
            query = query.Where(p => p.Name.Contains(filter.Name));
        }

        if (filter.Price != null)
        {
            query = query.Where(p => p.Price >= filter.Price);
        }
        
        return new Response<ResponseGetList<List<Product>>>
            (
                HttpStatusCode.OK,
                "Success",
                new ResponseGetList<List<Product>>
                {
                    Payload =await query
                        .Skip((filter.PageNumber-1)*filter.PageSize)
                        .Take(filter.PageSize).ToListAsync(),
                    Page=filter.PageNumber,
                    Size=filter.PageSize,
                    TotalRecords=await query.CountAsync()
                });
        
        
    }

    public async Task<Response<Product>> GetProductById(long id)
    {
        var product = await context.Products.FirstOrDefaultAsync(p=>p.Id == id);
        return product==null ? new Response<Product>(HttpStatusCode.NotFound, "Product not found")
            : new Response<Product>(HttpStatusCode.OK,"Found Successfully!", product);
    }

    public async Task<Response<string>> CreateProduct(AddProductDto productDto)
    {
        var product=mapper.Map<Product>(productDto);
        context.Products.Add(product);
        context.SaveChanges();
        return product==null ? new Response<string>(HttpStatusCode.NotFound, "Product not found")
                : new Response<string>(HttpStatusCode.Created,"Created Successfully!");
    }

    public async Task<Response<string>> UpdateProduct(UpdateProductDto productDto)
    {
        var product=await GetProductById(productDto.Id);
        if(product==null) return new Response<string>(HttpStatusCode.NotFound, "Product not found");
        product.Data.Name=productDto.Name;
        product.Data.Price = productDto.Price ?? product.Data.Price;
        context.Entry(product).CurrentValues.SetValues(productDto);
        await context.SaveChangesAsync();
        return product==null ? new Response<string>(HttpStatusCode.NotFound, "Product not found")
            : new Response<string>(HttpStatusCode.OK,"Updated successfully!");
    }

    public async Task<Response<string>> DeleteProduct(long id)
    {
        var product = context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
        return product==null ? new Response<string>(HttpStatusCode.NotFound, "Product not found")
            : new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }
}