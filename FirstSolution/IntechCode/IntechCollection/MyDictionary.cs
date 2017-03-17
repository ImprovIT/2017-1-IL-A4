﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IntechCode.IntechCollection
{
    public class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>
    {
        static readonly int[] _primes = {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369};

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
                return head.Data.Value;
            }
            set => DoAdd(key, value, true);
        }


        public int Count => _count;

        public void Add(TKey key, TValue value)
        {
            DoAdd(key, value, false);
        }

        private void DoAdd(TKey key, TValue value, bool allowUpdate)
        {
            int idxBucket = Math.Abs(key.GetHashCode()) % _buckets.Length;
            Node head = _buckets[idxBucket];
            if (head != null && FindIn(head, key) != null )
            {
                if(allowUpdate)
                {
                    head.Data = new KeyValuePair<TKey, TValue>(head.Data.Key, value);
                    return;
                }
                throw new Exception("Duplicate key.");
            }
            _buckets[idxBucket] = new Node()
            {
                Data = new KeyValuePair<TKey, TValue>(key, value),
                Next = head
            };
            ++_count;
        }

        Node FindIn(Node head, TKey key)
        {
            Debug.Assert(head != null);
            do
            {
                if (EqualityComparer<TKey>.Default.Equals(key, head.Data.Key)) break;
                head = head.Next;
            }
            while (head != null);
            return head;
        }

        public bool ContainsKey(TKey key)
        {
            int idxBucket = Math.Abs(key.GetHashCode()) % _buckets.Length;
            Node head = _buckets[idxBucket];
            if (head == null) throw new KeyNotFoundException("Clé invalide");
            return FindIn(head, key) != null;
        }

        class E : IMyEnumerator<KeyValuePair<TKey, TValue>>
        {

            readonly MyDictionary<TKey, TValue> _dictionnary;

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
