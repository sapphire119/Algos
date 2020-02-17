namespace Hierarchy.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public class Hierarchy<T> : IHierarchy<T>
    {
        //private Node<T> root;
        private Dictionary<T, Node<T>> hierarchy;

        public Hierarchy(T root)
        {
            //this.root = new Node<T>(root);
            this.hierarchy = new Dictionary<T, Node<T>>();
            //key -- parent
            this.hierarchy.Add(root, null);
        }

        public int Count
        {
            get
            {
                return this.hierarchy.Count;
                //var totalEleemntsInTree = 1 + this.GetCount(this.root);
                //return totalEleemntsInTree;
            }
        }

        //private int GetCount(Node<T> node, int count = 0)
        //{

        //    if (node.Children.Count != 0)
        //    {
        //        var temp = node;
        //        for (int i = 0; i < temp.Children.Count; i++)
        //        {
        //            var currentChild = temp.Children[i];
        //            if (currentChild.Children.Count == 0) continue;
        //            count += this.GetCount(currentChild);
        //        }
        //    }

        //    return count + node.Children.Count;
        //}

        public void Add(T element, T child)
        {
            if (!this.Contains(element) || this.Contains(child))
            {
                throw new ArgumentException();
            }


            var currentElement = this.GetElement(element, this.root);
            var childNode = new Node<T>(child, currentElement);
            currentElement.Children.Add(childNode);
            //currentElement.Count = currentElement.Children.Count;
        }

        //private Node<T> GetElement(T element, Node<T> node)
        //{
        //    //TODO Optimise this, its too slow
        //    if (!node.Value.Equals(element))
        //    {
        //        var temp = node;
        //        for (int i = 0; i < temp.Children.Count; i++)
        //        {
        //            var currentChild = temp.Children[i];
        //            node = this.GetElement(element, currentChild);
        //            if (node.Value.Equals(element)) break;
        //        }
        //    }
        //    //else
        //    //{
        //    //    return node;
        //    //}

        //    return node;
        //}

        public void Remove(T element)
        {
            //TODO Add Remove logic
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.Contains(item))
            {
                throw new ArgumentException();
            }
            var element = this.GetElement(item, this.root);
            var childElements = element.Children.Select(e => e.Value);

            return childElements;
        }

        public T GetParent(T item)
        {
            if (!this.hierarchy.ContainsKey(item))
            {
                throw new ArgumentException();
            }
            var parentNode = this.hierarchy[item];
            
            //var element = this.GetElement(item, this.root);
            //if (!element.Value.Equals(item))
            //{
            //    throw new ArgumentException();
            //}

            return parentNode == null ? default(T) : parentNode.Value;
        }

        public bool Contains(T value)
        {
            return this.hierarchy.ContainsKey(value);
            //var element = this.GetElement(value, this.root);
            //if (element.Value.Equals(value))
            //{
            //    return true;
            //}

            //return false;
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var test = new Dictionary<T, Node<T>>();

            //TODO Add GetCommonElements logic
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //TODO Add GetEnumerator logic

            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}