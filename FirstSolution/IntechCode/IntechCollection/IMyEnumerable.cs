using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.IntechCollection
{
    public interface IMyEnumerable<T>
    {
        IMyEnumerator<T> GetEnumerator();
    }
}
