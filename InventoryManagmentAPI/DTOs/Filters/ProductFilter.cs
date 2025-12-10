using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.DTOs.Filters;

public class ProductFilter
{
    public long? Id { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public long? CategoryId { get; set; }
    
    
}