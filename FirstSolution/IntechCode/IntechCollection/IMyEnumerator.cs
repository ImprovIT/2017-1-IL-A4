using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.IntechCollection
{
    public interface IMyEnumerator<T>
    {
        T Current { get; }

        bool MoveNext();
    }
}
