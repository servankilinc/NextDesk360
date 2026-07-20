using System.Collections.Concurrent;
using System.Reflection;

namespace ExpressDesk360.Core.Utils.DynamicQuery;

/// <summary>
/// Whitelists the field names that may be interpolated into a Dynamic LINQ expression.
/// <para>
/// Filter/sort field names arrive from the client and are concatenated straight into the
/// expression string, so an unvalidated name lets a caller reach any mapped column - including
/// ones that never appear in a DTO (password hashes, security stamps, refresh tokens) - and use
/// the returned row count as a boolean oracle. Only real properties of the queried type are
/// allowed, and navigation traversal is limited to <see cref="MaxDepth"/> segments.
/// </para>
/// </summary>
public static class DynamicFieldValidator
{
    /// <summary>How many dot-separated segments a field may contain (e.g. "Company.Name" = 2).</summary>
    public const int MaxDepth = 2;

    /// <summary>
    /// Property names that must never be exposed to a client-supplied expression, whatever the
    /// entity looks like. Matched case-insensitively on the final segment.
    /// </summary>
    private static readonly HashSet<string> BlockedNames = new(StringComparer.OrdinalIgnoreCase)
    {
        "PasswordHash",
        "SecurityStamp",
        "ConcurrencyStamp",
        "Token",
        "TwoFactorEnabled",
        "LockoutEnd",
        "AccessFailedCount"
    };

    private static readonly ConcurrentDictionary<(Type, string), bool> _cache = new();

    /// <summary>
    /// Throws <see cref="ArgumentException"/> when <paramref name="field"/> is not a readable
    /// property path on <typeparamref name="T"/>.
    /// </summary>
    public static void EnsureValidField<T>(string? field)
    {
        if (string.IsNullOrWhiteSpace(field))
            throw new ArgumentException("Empty field for dynamic query");

        if (!_cache.GetOrAdd((typeof(T), field), key => IsValidPath(key.Item1, key.Item2)))
            throw new ArgumentException($"Invalid or not permitted field for dynamic query: {field}");
    }

    private static bool IsValidPath(Type rootType, string field)
    {
        var segments = field.Split('.', StringSplitOptions.TrimEntries);
        if (segments.Length == 0 || segments.Length > MaxDepth) return false;

        Type current = rootType;

        for (int i = 0; i < segments.Length; i++)
        {
            string segment = segments[i];
            if (segment.Length == 0) return false;
            if (BlockedNames.Contains(segment)) return false;

            PropertyInfo? property = current.GetProperty(
                segment,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (property is null || !property.CanRead) return false;

            current = UnwrapType(property.PropertyType);
        }

        return true;
    }

    /// <summary>Unwraps Nullable&lt;T&gt; and collection element types so navigation paths resolve.</summary>
    private static Type UnwrapType(Type type)
    {
        Type? underlying = Nullable.GetUnderlyingType(type);
        if (underlying is not null) return underlying;

        if (type != typeof(string) && type.IsGenericType)
        {
            Type definition = type.GetGenericTypeDefinition();
            if (definition == typeof(ICollection<>) || definition == typeof(IEnumerable<>) ||
                definition == typeof(List<>) || definition == typeof(IList<>))
            {
                return type.GetGenericArguments()[0];
            }
        }

        return type;
    }
}
