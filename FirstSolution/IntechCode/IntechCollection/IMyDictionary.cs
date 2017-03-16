using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.IntechCollection
{
    public interface IMyDictionary<TKey,TValue>
    {
        /// <summary>
        /// Add e key-value pair. The key must not already exist.
        /// </summary>
        /// <param name="key">The key to add</param>
        /// <param name="value">The value to add</param>
        void Add(TKey key, TValue value);

        bool ContainsKey(TKey key);

        /// <summary>
        /// Sets the value associated to a key
        /// When the key does not exist <see cref="KeyNotFoundException"/>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue this[TKey key] { get;set; }

        bool TryGetValue(TKey key, out TValue value);

        int Count { get; }

        bool Remove(TKey key);

    }
}
