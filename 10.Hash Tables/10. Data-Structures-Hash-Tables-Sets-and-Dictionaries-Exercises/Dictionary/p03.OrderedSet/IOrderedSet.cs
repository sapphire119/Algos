using System;
using System.Collections.Generic;

namespace p03.OrderedSet
{
    public interface IOrderedSet<T> where T : IComparable
    {
        void Add(T element);
        bool Contains(T element);
        void Remove(T element);
        int Count { get; }
    }
}
