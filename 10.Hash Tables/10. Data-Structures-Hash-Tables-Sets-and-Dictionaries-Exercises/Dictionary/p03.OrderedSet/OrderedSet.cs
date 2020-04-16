using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Trees;

namespace p03.OrderedSet
{
    public class OrderedSet<T> : IEnumerable<T>, IOrderedSet<T> where T : IComparable
    {
        private RedBlackTree<T> redBlackTree;

        public OrderedSet()
        {
            this.redBlackTree = new RedBlackTree<T>();
        }

        public int Count => this.redBlackTree.Count();

        public void Add(T element)
        {
            this.redBlackTree.Insert(element);
        }

        public bool Contains(T element)
        {
            return this.redBlackTree.Contains(element);
        }

        public void Remove(T element)
        {
            this.redBlackTree.Delete(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> list = new List<T>();
            this.redBlackTree.EachInOrder(list.Add);
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
