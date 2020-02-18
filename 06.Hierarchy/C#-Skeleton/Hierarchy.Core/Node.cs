namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public Node(T value, T parent)
            :this(value)
        {
            this.Parent = new Node<T>(parent);
        }

        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }

        public Node<T> Parent { get; set; }
        //public Node(T value, Node<T> parent)
        //    :this(value)
        //{
        //    this.Parent = parent;
        //}
        //public Node(T value)
        //{
        //    this.Value = value;
        //    this.Children = new List<Node<T>>();
        //}

        //public Node(T value, Node<T> parent)
        //    :this(value)
        //{
        //    this.Parent = parent;
        //}

        //public Node<T> Parent { get; set; }
        //public List<Node<T>> Children { get; set; }
    }
}
