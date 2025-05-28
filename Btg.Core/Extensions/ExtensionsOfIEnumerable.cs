namespace Btg.Core.Extensions;

public static class ExtensionsOfIEnumerable
{
    /// <inheritdoc cref="Enumerable.ExceptBy{TSource, TKey}(IEnumerable{TSource}, IEnumerable{TKey}, Func{TSource, TKey}, IEqualityComparer{TKey}?)"/>
    public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
    {
        return first.ExceptBy(second.Select(keySelector), keySelector);
    }

    /// <inheritdoc cref="Enumerable.IntersectBy{TSource, TKey}(IEnumerable{TSource}, IEnumerable{TKey}, Func{TSource, TKey}, IEqualityComparer{TKey}?)"/>
    public static IEnumerable<TSource> IntersectBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
    {
        return first.IntersectBy(second.Select(keySelector), keySelector);
    }
}