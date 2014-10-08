using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.LINQ.MapReduce
{
    public static class ExtensionLinq
    {
        public static IEnumerable<TResult> MapReduce<TSource, TMapped, TKey, TResult>
            (this IEnumerable<TSource> source,
             Func<TSource, IEnumerable<TMapped>> map,
             Func<TMapped, TKey> keySelector,
             Func<IGrouping<TKey, TMapped>, IEnumerable<TResult>> reduce)
        {
            return source.SelectMany(map)
                         .GroupBy(keySelector)
                         .SelectMany(reduce);
        }

        // PLINQ version
        public static ParallelQuery<TResult> MapReduce<TSource, TMapped, TKey, TResult>
            (this ParallelQuery<TSource> source,
             Func<TSource, IEnumerable<TMapped>> map,
             Func<TMapped, TKey> keySelector,
             Func<IGrouping<TKey, TMapped>, IEnumerable<TResult>> reduce)
        {
            return source.SelectMany(map)
            .GroupBy(keySelector)
            .SelectMany(reduce);
        }
    }
}
