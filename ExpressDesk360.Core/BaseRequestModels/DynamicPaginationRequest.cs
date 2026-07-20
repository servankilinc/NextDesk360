using ExpressDesk360.Core.Utils.DynamicQuery;
using ExpressDesk360.Core.Utils.Pagination;

namespace ExpressDesk360.Core.BaseRequestModels;

public class DynamicPaginationRequest : PaginationRequest
{
    public Filter? Filter { get; set; }
    public IEnumerable<Sort>? Sorts { get; set; }
}
