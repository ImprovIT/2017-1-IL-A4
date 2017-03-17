using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IntechCode.IntechCollection
{
    public class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>
    {
        class Node
        {
            public KeyValuePair<TKey, TValue> Data;
            public Node Next;
        }
        Node[] _buckets;
        int _count;

        public MyDictionary()
        {
            _buckets = new Node[7];
        }

        public TValue this[TKey key]
        {
            get
            {
                int idxBucket = Math.Abs(key.GetHashCode()) % _buckets.Length;
                Node head = _buckets[idxBucket];
                if (FindIn(head, key) == null) throw new KeyNotFoundException("Clé invalide.");
                return head.Data.value;
            }
        }


        public int Count => _count;

        public void Add(TKey key, TValue value)
        {
            int idxBucket = Math.Abs(key.GetHashCode()) % _buckets.Length;
            Node head = _buckets[idxBucket];
            if (head != null && FindIn(head, key) != null)
            {
                throw new Exception("Duplicate key.");
            }
            _buckets[idxBucket] = new Node()
            {
                Data = new KeyValuePair<TKey, TValue>(key, value),
                Next = null
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
            int idxBucket = Math.Abs(key.GetHashCode()) % _buckets.Length;
            Node head = _buckets[idxBucket];
            return FindIn(head, key) != null;
        }

        class E : IMyEnumerator<KeyValuePair<TKey, TValue>>
        {

            readonly MyDictionary<TKey, TValue> _dictionnary;
            int _currentIndex;

            public E(MyDictionary<TKey, TValue> theDictionnary)
            {
                _dictionnary = theDictionnary;
            }
            public KeyValuePair<TKey, TValue> Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                return false;
            }
        }

        public IMyEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new E(this);
        }

        public bool Remove(TKey key)
        {
            int idxBucket = Math.Abs(key.GetHashCode()) % _buckets.Length;
            Node head = _buckets[idxBucket];
            if (head != null && FindIn(head, key) != null)
            {
                
            }
            else
            {
                throw new KeyNotFoundException("Clé invalide");
            }
            return false;    
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }
    }
}
