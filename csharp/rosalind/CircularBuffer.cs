using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace rosalind
{
    public class CircularBuffer<T> : IEnumerable<T>
    {
        readonly int capacity_;
        int size_;
        ModularInt head_;
        T[] buff_;

        [ContractInvariantMethod]
        public void ObjectInvariant () 
        {
            Contract.Invariant (head_.mod == capacity_);
            Contract.Invariant (size_ <= capacity_);
        }

        public CircularBuffer (int capacity)
        {
            capacity_ = capacity;
            head_ = new ModularInt(0, capacity_);
            size_ = 0;
            buff_ = new T[capacity_];
        }

        public int capacity {
            get { return capacity_; }
        }

        public int size {
            get { return size_; }
        }

        public T this[int index]
        {
            get {
                Contract.Assert (index < size);
                var offset = head_ + index;
                return buff_ [offset.value];
            }

            set {
                Contract.Assert (index < size);
                var offset = head_ + index;
                buff_ [offset.value] = value;
            }
        }

        public T popFront()
        {
            Contract.Assert (size > 0);
            var index = head_;
            head_ = head_ + 1;
            size_ -= 1;
            return buff_ [index.value];
        }

        public T popBack()
        {
            Contract.Assert (size > 0);
            size_ -= 1;
            return buff_ [(int)(head_ + size_)];
        }

        public void pushFront(T val)
        {
            Contract.Assert(size < capacity);
            head_ = head_ - 1;
            size_ += 1;
            buff_ [head_.value] = val;
        }

        public void pushBack(T val)
        {
            Contract.Assert (size < capacity);
            buff_ [(int)(head_ + size)] = val;
            size_ += 1;
        }

        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < size; ++i) {
                yield return this [i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

