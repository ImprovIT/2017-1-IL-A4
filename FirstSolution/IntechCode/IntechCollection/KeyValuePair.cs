using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.IntechCollection
{
    public struct KeyValuePair<Tkey, TValue>
    {
        public readonly Tkey key;
        public readonly TValue value;

        public KeyValuePair(Tkey k, TValue v)
        {
            key = k;
            value = v;
        }
    }
}
