namespace Mehr.Domain.Paginations;

public class PaginationRequestQuery
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string Search { get; set; }
}

