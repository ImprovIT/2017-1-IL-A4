using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IntechCode.IntechCollection
{
    public class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>
    {

        public class Node
        {
            public KeyValuePair<TKey, TValue> Data;
            public Node Next;
        }

        public Node[] _buckets;
        public int _count;

        public MyDictionary()
        {
            _buckets = new Node[7];
            _count = 0;
        }

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => _count;

        public void Add(TKey key, TValue value)
        {
            int idxBucket = key.GetHashCode() % _buckets.Length;
            Node head = _buckets[idxBucket];
            if(head != null && FindIn(head, key) != null)
            {
                throw new Exception("Duplicated key");
            }
            _buckets[idxBucket] = new Node()
            {
                Data = new KeyValuePair<TKey, TValue>(key, value),
                Next = head
            };
            ++_count;
        }

         object FindIn(Node head, TKey key)
        {
            Debug.Assert(head != null);
            do
            {
                if (EqualityComparer<TKey>.Default.Equals(key, head.Data.key)) break;
                head = head.Next;
            }
            while (head != null);
            return head;
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public IMyEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }
    }
}
