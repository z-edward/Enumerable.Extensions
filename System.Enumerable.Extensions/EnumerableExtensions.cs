using System.Collections.Generic;

namespace System.Enumerable.Extensions {
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
    }
}
