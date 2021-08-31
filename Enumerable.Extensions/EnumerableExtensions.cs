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


        /// <summary>
        /// Fast transform enumerable to array known size
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <param name="source">Source enumerable</param>
        /// <param name="count">size of target array</param>
        /// <returns>Array of elements</returns>
        /// <remarks>If array size greater than number elements in enumerable, elements will emptys</remarks>
        public static T[] ToArray<T>(this IEnumerable<T> source, int count) {
            var result = new T[count];
            using var enumerator = source.GetEnumerator();
            for (var i=0;i < count; i++) 
                if (enumerator.MoveNext()) result[i] = enumerator.Current;
                else break;
            return result;
        }
    }
}
