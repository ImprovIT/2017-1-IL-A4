using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.IntechCollection
{
    public struct KeyValuePair<TKey, TValue>
    {
        public readonly TKey key;
        public readonly TValue value;

        public KeyValuePair(TKey k, TValue v)
        {
            key = k;
            value = v;
        }
    }
}
