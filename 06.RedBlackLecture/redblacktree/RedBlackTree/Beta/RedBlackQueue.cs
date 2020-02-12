﻿using System.Linq;

namespace System.Collections.Generic.RedBlack.Beta
{
    /// <summary>
    /// RedBlack Tree-based priority queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1035:ICollectionImplementationsHaveStronglyTypedMembers")]
    public class RedBlackQueue<T>
        : IEnumerable<T>, ICollection
        where T : class
    {
        readonly RedBlackTree<QueuePriority, T> _internalTree = new RedBlackTree<QueuePriority, T>();

        public void Enqueue(T item)
        {
            lock (this)
            {
                _internalTree.Add(new QueuePriority(), item);
            }
        }

        public void Enqueue(T item, byte priority)
        {
            lock (this)
            {
                _internalTree.Add(new QueuePriority(priority), item);
            }
        }

        public T Dequeue()
        {
            lock (this)
            {
                T result = _internalTree.GetMinValue();
                _internalTree.RemoveMin();
                return result;
            }
        }

        public T Peek()
        {
            return _internalTree.GetMinValue();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            return _internalTree.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _internalTree.GetEnumerator();
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing. </param><param name="index">The zero-based index in <paramref name="array"/> at which copying begins. </param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero. </exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or- The number of elements in the source <see cref="T:System.Collections.ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.-or-The type of the source <see cref="T:System.Collections.ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception><filterpriority>2</filterpriority>
        [Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
        public void CopyTo(Array array, int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", "Index cannot be less than 0");
            if (array == null)
                throw new ArgumentNullException("array", "Array cannot be null");
            if ((array.Length - index) < Count)
                throw new ArgumentException();
            int _currentPosition = index;
            foreach (T item in _internalTree.GetAll()
                .Select(i => i.Data))
            {
                array.SetValue(item, _currentPosition);
                _currentPosition++;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public int Count { get { return _internalTree.Count; } }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <returns>
        /// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public object SyncRoot { get { return this; } }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <returns>
        /// true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public bool IsSynchronized { get { return false; } }

        #region "Private"

        internal class QueuePriority : IComparable<QueuePriority>, IComparable, IEquatable<QueuePriority>
        {
            public byte Priority { get; set; }
            public long Sequence { get; private set; }

            /// <summary>
            /// Initializes priority with default value of 100
            /// </summary>
            public QueuePriority()
                : this(100)
            { }

            /// <summary>
            /// Initializes priority
            /// </summary>
            /// <param name="priority">priority value, lesser means will be executed sooner</param>
            public QueuePriority(byte priority)
            {
                Priority = priority;
                Sequence = DateTime.UtcNow.Ticks;
            }

            public int CompareTo(QueuePriority other)
            {
                int compare = 0;
                compare = Priority.CompareTo(other.Priority);
                if (compare == 0)
                    compare = Sequence.CompareTo(other.Sequence);

                return compare;
            }

            /// <summary>
            /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
            /// </summary>
            /// <returns>
            /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj"/>. Greater than zero This instance follows <paramref name="obj"/> in the sort order. 
            /// </returns>
            /// <param name="obj">An object to compare with this instance. </param><exception cref="T:System.ArgumentException"><paramref name="obj"/> is not the same type as this instance. </exception><filterpriority>2</filterpriority>
            public int CompareTo(object obj)
            {
                QueuePriority castedOther = obj as QueuePriority;
                if (castedOther != null)
                    return CompareTo(castedOther);
                return 0;
            }

            public bool Equals(QueuePriority other)
            {
// ReSharper disable SuspiciousTypeConversion.Global
                return Priority.Equals(other) && Sequence.Equals(other);
// ReSharper restore SuspiciousTypeConversion.Global
            }
        }

        #endregion
    }
}
