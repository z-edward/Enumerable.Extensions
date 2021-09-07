using System;
using System.Collections.Generic;

namespace Enumerable.Extensions {
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
        /// <returns>Value</returns>
        public static T GetOrdAdd<TKey, T>(this IDictionary<TKey, T> @this, TKey key, Func<TKey, T> add) {
            return @this.GetOrdAdd(key, add(key));
        }
        
        /// <summary>
        /// Get value from dictionary, or add it, if not exists
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="this">Dictionary</param>
        /// <param name="key">Key value</param>
        /// <param name="add">Value factory</param>
        /// <returns>Value</returns>
        public static T GetOrdAdd<TKey, T>(this IDictionary<TKey, T> @this, TKey key, Func<T> add) {
           return @this.GetOrdAdd(key, add());
        }

        /// <summary>
        /// Get value from dictionary, or add it, if not exists
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="this">Dictionary</param>
        /// <param name="key">Key value</param>
        /// <param name="value">Value</param>
        /// <returns>Value</returns>
        public static T GetOrdAdd<TKey, T>(this IDictionary<TKey, T> @this, TKey key, T value) { 
            T Add() { 
                @this.Add(key,value);
                return value;
            }
            return @this.ContainsKey(key) ? @this[key] : Add();
        }
        
        
    }
}
