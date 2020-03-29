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

        public void Insert(Node<T> node)
        {
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

        public int Delete(Node<T> node)
        {
            for (int i = 0; i < node.Duplicates.Count; i++)
            {
                var currentNode = node.Duplicates[i];
                this.DeleteNode(currentNode);
            }
            this.DeleteNode(node);

            var deletedNodesCount = node.Duplicates.Count + 1;
            this.count -= deletedNodesCount;

            return deletedNodesCount;
        }

        private void DeleteNode(Node<T> node)
        {
            var currentNodeHead = node.Head;
            var currentNodeTail = node.Tail;

            //var temp = node;
            if (currentNodeHead != null) currentNodeHead.Tail = node.Tail;
            else this.head = this.head.Tail;

            if (currentNodeTail != null) currentNodeTail.Head = node.Head;
            else this.tail = this.tail.Head;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
    }
}
