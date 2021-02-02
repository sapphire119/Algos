namespace p01.Index
{
    using System;
    using System.Collections.Generic;

    public class Node : IComparable<Node>
    {
        public Node(int id, int value, int distanceFromStart = int.MaxValue)
        {
            this.Id = id;
            this.Value = value;
            this.Children = new List<Node>();
            this.DistanceFromStart = distanceFromStart;
            this.Parent = null;
        }

        public Node Parent { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        public int DistanceFromStart { get; set; }
        public List<Node> Children { get; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }

        public override string ToString()
        {
            return $"{this.Id}, {this.Value} --< {this.DistanceFromStart}";
        }
    }
}