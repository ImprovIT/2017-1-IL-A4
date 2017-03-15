using System;

namespace IntechCode.IntechCollection
{
    public class MyList<T> : IMyList<T>
    {
        private int _sizeArray = 5;
        private T[] _array;
        private int _currentIndex;

        public MyList()
        {
            this._array = new T[this._sizeArray];
            this._currentIndex = 0;
        }
        public MyList(int sizeArray)
        {
            this._array = new T[sizeArray];
            this._currentIndex = 0;
        }

        public T this[int index] 
        {
            get => this._array[index];
            set => this._array[index] = value;
        }

        public int Count => this._currentIndex;

        public void Add(T item)
        {
            if (NeedToExpandArray())
                ExpandArray();
            this._array[_currentIndex] = item;
            this._currentIndex++;
        }

        public int IndexOf(T item)
        {
            for(int i=0; i < this._currentIndex - 1; i++)
            {
                if (item.Equals(this._array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if(index <= this.Count)
            {
                if (NeedToExpandArray())
                    ExpandArray();
                for (int i = this._currentIndex; i > index; i--)
                {
                    this._array[i + 1] = this._array[i];
                }
                this._array[index] = item;
                this._currentIndex++;
            }
            //throw exception
        }

        public void RemoveAt(int index)
        {
            //TO DO
            if (index <= this.Count)
            {
                this._array[index] = default(T);
            }
        }

        private bool NeedToExpandArray()
        {
            return this._currentIndex+1 == this._array.Length;
        }

        private void ExpandArray()
        {
            T[] tmpArray = new T[this._array.Length * + 1];
            for(int i = 0; i<this._array.Length; i++)
            {
                tmpArray[i] = this._array[i];
            }
            this._array = tmpArray;
        }
    }
}
