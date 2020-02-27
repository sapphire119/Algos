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
        private T root;
        //private int lastElementCount = 1;

        public Hierarchy(T root)
        {
            this.root = root;
            this.hierarchy = new Dictionary<T, Node<T>>();
            this.hierarchy.Add(root, new Node<T>(root));
            //this.root = new Node<T>(root);
            //key -- parent
            //TODO Refactor
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

            var elementNode = this.hierarchy[element];
            var childNode = new Node<T>(child, elementNode);
            elementNode.Children.Add(childNode);
            this.hierarchy.Add(child, childNode);

            //lastElementCount++;
            //var parentNode = this.hierarchy[element];
            //this.hierarchy.Add(element);
            //this.hierarchy.Add(child, new Node<T>())
            //var currentElement = this.GetElement(element, this.root);
            //var childNode = new Node<T>(child, currentElement);
            //currentElement.Children.Add(childNode);
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
            if (element.Equals(this.root))
            {
                throw new InvalidOperationException();
            }
            if (!this.Contains(element))
            {
                throw new ArgumentException();
            }
            var elementToRemove = this.hierarchy[element];
            var parentNode = elementToRemove.Parent;
            parentNode.Children.Remove(elementToRemove);
            if (elementToRemove.Children.Count > 0)
            {
                foreach (var childNode in elementToRemove.Children)
                {
                    childNode.Parent = parentNode;
                    childNode.Depth = parentNode.Depth + 1;
                }
                parentNode.Children.AddRange(elementToRemove.Children);
            }

            //if (elementToRemove.Parent != null)
            //{
                
            //}
            //TODO Add Remove logic
            //Check for Reference deletion from List
            this.hierarchy.Remove(element);
            //throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.Contains(item))
            {
                throw new ArgumentException();
            }

            var currentElementNode = this.hierarchy[item];
            var childrenElemnts = currentElementNode.Children.Select(e => e.Value);
            //this.
            //var element = this.GetElement(item, this.root);
            //var childElements = element.Children.Select(e => e.Value);

            return childrenElemnts;
            //return childElements;
        }

        public T GetParent(T item)
        {
            if (!this.hierarchy.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            var currentEleNode = this.hierarchy[item];
            var parentValue = currentEleNode.Parent != null ? currentEleNode.Parent.Value : default(T);

            return parentValue;
            //return parent;
            //var element = this.GetElement(item, this.root);
            //if (!element.Value.Equals(item))
            //{
            //    throw new ArgumentException();
            //}

            //return parentNode == null ? default(T) : parentNode.Value;
        }

        public bool Contains(T value)
        {
            return this.hierarchy.ContainsKey(value);
            //this.hierarchy[]
            //return this.hierarchy.ContainsKey(key => key.Value == value);
            //var element = this.GetElement(value, this.root);
            //if (element.Value.Equals(value))
            //{
            //    return true;
            //}

            //return false;
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var collection = this.hierarchy.Keys.Intersect(other.hierarchy.Keys);
            return collection;
            //TODO Add GetCommonElements logic
            //throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var rootNode = this.hierarchy[this.root];

            var children = new Queue<Node<T>>();
            children.Enqueue(rootNode);

            while (children.Count > 0)
            {
                var currentElement = children.Dequeue();
                yield return currentElement.Value;

                foreach (var child in currentElement.Children)
                {
                    children.Enqueue(child);
                }
            }
            //5 Children -> In order of entry -> 50, 70
            //50 Children --> ---||----|| --> 200, 300


            //var temp = this.hierarchy
            //    .OrderBy(x => x.Value.Depth)
            //    .ToDictionary(x => x.Key, x => x.Value);


            ////var rootNode = this.hierarchy[this.root];

            //foreach (var key in temp.Keys)
            //{
            //    yield return key;
            //}
            //yield return default;
            //foreach (var key in this.hierarchy.Keys)
            //{
            //    yield return key;
            //}
        }

        //private IEnumerable<T>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}