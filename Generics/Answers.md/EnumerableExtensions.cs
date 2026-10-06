public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be at least 1.");
        if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be at least 1.");
        var start = (long)(pageNumber - 1) * pageSize;
        long index = 0; var yielded = 0;
        foreach (var item in source)
        {
            if (index >= start && yielded < pageSize) { yield return item; yielded++; }
            if (yielded == pageSize) yield break;
            index++;
        }
    }

    public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);
        foreach (var item in source) if (item.Id == id) return item;
        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);
        var result = new Dictionary<int, T>();
        foreach (var item in source)
        {
            if (!result.TryAdd(item.Id, item))
                throw new ArgumentException($"Duplicate Id {item.Id} found in source.", nameof(source));
        }
        return new System.Collections.ObjectModel.ReadOnlyDictionary<int, T>(result);
    }
}
