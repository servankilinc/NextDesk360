using System.Linq.Dynamic.Core;

namespace ExpressDesk360.Core.Utils.DynamicQuery;

public static class QueryableSortExtension
{
    private static readonly string[] _orderDirs = { "asc", "desc" };
    
    public static IQueryable<T> ToSort<T>(this IQueryable<T> queryable, IEnumerable<Sort> sorts)
    {
        if (sorts is not null)
        {
            foreach (Sort item in sorts)
            {
                // Field is interpolated into the ordering string, so it must be whitelisted.
                DynamicFieldValidator.EnsureValidField<T>(item.Field);
                if (string.IsNullOrEmpty(item.Dir) || !_orderDirs.Contains(item.Dir)) throw new ArgumentException("Invalid Order Type For Sorting Process");
            }

            string ordering = string.Join(separator: ",", values: sorts.Select(s => $"{s.Field} {s.Dir}"));
            return queryable.OrderBy(ordering);
        }

        return queryable;
    }
}
