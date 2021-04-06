using System;
using System.Collections.Generic;

namespace System.Enumerable.Extensions {
    /// <summary>
    /// Dictionary extensions methods
    /// </summary>
    public static class DictionaryExtensions {
        /// <summary>
        /// Get item from dictionary, or default value
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="this">Dictionary</param>
        /// <param name="key">Key value</param>
        /// <param name="default">Default value</param>
        /// <returns>Value or default value</returns>
        public static T GetOrDefault<TKey, T>(this IReadOnlyDictionary<TKey, T> @this, TKey key, T @default = default) {
            return @this.ContainsKey(key) ? @this[key] : @default;
        }


        /// <summary>
        /// Get value from dictionary, or add it, if not exists
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="this">Dictionary</param>
        /// <param name="key">Key value</param>
        /// <param name="add">Value factory</param>
        /// <returns></returns>
        public static T GetOrdAdd<TKey, T>(this IDictionary<TKey, T> @this, TKey key, Func<T> add) {

            T factory() { T v = add(); @this.Add(key, v ); return v; }
            return @this.ContainsKey(key) ? @this[key] : factory();
        } 
        
    }
}
