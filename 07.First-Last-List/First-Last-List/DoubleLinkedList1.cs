namespace First_Last_List
{
    using System;

    public class DoubleLinkedList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public DoubleLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public Node<T> Head => this.head;
        public Node<T> Tail => this.tail;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Insert(T element)
        {
            var node = new Node<T>(element);
            if (this.head == null && this.tail == null)
            {
                this.head = node;
                this.tail = node;
                this.count++;
                return;
            }

            ;
            node.Tail = this.head;
            this.head.Head = node;
            this.head = node;
            this.count++;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
        }
    }
}
