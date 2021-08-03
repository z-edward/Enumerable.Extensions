using System;
using System.Collections.Generic;

namespace Enumerable.Extensions {
    public static class EnumerableExtensions {
        /// <summary>
        /// Allow use methods with IEmunerable arguments as params T[] 
        /// </summary>
        /// <typeparam name="T">Type of IEnumerable</typeparam>
        /// <param name="parameters">parametrs values</param>
        /// <returns>Parameters values as IEnumerable</returns>
        /// <remarks>
        /// Usage: 
        /// Sample api method <code>Api(IEnumerable<int> values)</code> ...
        /// Allow call: <code>Api(EnumerableExtensions.Enumerate(1,2,3));</code>
        /// </remarks>
        public static IEnumerable<T> Enumerate<T>(params T[] parameters) => parameters;

        /// <summary>
        /// Transform <typeparamref name="TSource"/> to <typeparamref name="TResult"/> using index
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="result">Result factory</param>
        /// <param name="filter">Filter on source expressions</param>
        /// <returns>Result</returns>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IReadOnlyList<TSource> source, Func<TSource, int, TResult> result, Func<TSource, int, bool> filter = null) {
            for (var i=0; i<source.Count; i++) {
                var s = source[i];
                var fr = filter == null ? true : filter(s,i);
                if (fr) yield return result(s, i);
            } 
        }
        /// <summary>
        /// Build chain result by handling secuance of enumerable
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="source">Source enumerable</param>
        /// <param name="selectorNext">Function to build result for intermediate values</param>
        /// <param name="selectorLast">Function to build result for end value</param>
        /// <returns>Build result</returns>
        public static TResult Chain<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult, TResult> selectorNext, Func<TSource, TResult> selectorLast)
        {
            using var se = source.GetEnumerator(); 
            TResult InternalChain(TSource current)
            {
                return se.MoveNext() ? selectorNext(current, InternalChain(se.Current)) : selectorLast(current);
            }
            return se.MoveNext() ? InternalChain(se.Current) : default;
        }
    }
}
