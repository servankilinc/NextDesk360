using ExpressDesk360.Core.Utils.DynamicQuery;

namespace ExpressDesk360.Core.BaseRequestModels;

public class DynamicRequest
{
    public Filter? Filter { get; set; }
    public IEnumerable<Sort>? Sorts { get; set; }
}
