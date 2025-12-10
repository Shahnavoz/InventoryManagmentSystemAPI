namespace InventoryManagmentAPI.DTOs.Filters;

public class SupplyFilter
{
    public long? Id { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int? SupplyCount { get; set; }
}