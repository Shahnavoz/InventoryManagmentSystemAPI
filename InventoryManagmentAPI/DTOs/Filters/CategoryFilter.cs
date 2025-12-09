using InventoryManagmentAPI.Entities;

namespace InventoryManagmentAPI.DTOs.Filters;

public class CategoryFilter:BaseEntity
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; }=10;
    public string Name { get; set; }
    public string Description { get; set; }
    
}