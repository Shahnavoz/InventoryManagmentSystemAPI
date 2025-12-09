namespace MiniLibraryAPI.Responses;

public class ResponseGetList<T>
{
    public T? Payload { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public int TotalRecords { get; set; }
    
}