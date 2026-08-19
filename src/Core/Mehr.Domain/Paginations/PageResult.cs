namespace Mehr.Domain.Paginations;

public class PageResult<T>
{
    public List<T> Data { get; set; } = new();
    public PaginationMeta Meta { get; set; } = new();

}

public class PaginationMeta
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
}

