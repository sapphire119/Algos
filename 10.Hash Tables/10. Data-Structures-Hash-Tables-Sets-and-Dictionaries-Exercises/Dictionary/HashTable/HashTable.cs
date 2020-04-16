using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int InitialCapacity = 16;
    private const float LoadFactor = 0.75f;

    private LinkedList<KeyValue<TKey, TValue>>[] slots;

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }

    public HashTable(int capacity = InitialCapacity)
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.Count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        GrowIfNeeded();
        int slotHash = this.FindSlotHash(key);
        if (this.slots[slotHash] == null)
        {
            this.slots[slotHash] = new LinkedList<KeyValue<TKey, TValue>>();
        }
        foreach (var kvp in this.slots[slotHash])
        {
            if (kvp.Key.Equals(key))
            {
                throw new ArgumentException(string.Concat("Key already exists: ", key));
            }
        }

        var newKvp = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotHash].AddLast(newKvp);
        this.Count++;
        //throw new NotImplementedException();
        // Note: throw an exception on duplicated key
    }

    private void GrowIfNeeded()
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }
    }

    private void Grow()
    {
        var newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);
        foreach (var kvp in this)
        {
            newHashTable.Add(kvp.Key, kvp.Value);
        }

        this.slots = newHashTable.slots;
        this.Count = newHashTable.Count;
    }

    private int FindSlotHash(TKey key)
    {
        return (key.GetHashCode() & 0x7FFFFFFF) % this.slots.Length;
        //throw new NotImplementedException();
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        GrowIfNeeded();
        int slotHash = this.FindSlotHash(key);
        if (this.slots[slotHash] == null)
        {
            this.slots[slotHash] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var kvp in this.slots[slotHash])
        {
            if (kvp.Key.Equals(key))
            {
                kvp.Value = value;
                return false;
            }
        }

        var newKvp = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotHash].AddLast(newKvp);
        this.Count++;

        return true;
    }

    public TValue Get(TKey key)
    {
        var kvp = this.Find(key);
        if (kvp == null)
        {
            throw new KeyNotFoundException();
        }

        return kvp.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key);
            // Note: throw an exception on missing key
        }
        set
        {
            this.AddOrReplace(key, value);
            //throw new NotImplementedException();
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var kvp = this.Find(key);
        if (kvp != null)
        {
            value = kvp.Value;
            return true;
        }

        value = default;
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        var hashCode = this.FindSlotHash(key);
        var linkedList = this.slots[hashCode];
        if (linkedList != null)
        {
            foreach (var kvp in linkedList)
            {
                if (kvp.Key.Equals(key))
                {
                    return kvp;
                }
            } 
        }

        return default;
    }

    public bool ContainsKey(TKey key)
    {
        return this.Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        var hashCode = this.FindSlotHash(key);

        var linkedList = this.slots[hashCode];
        if (linkedList != null)
        {
            var test = linkedList.First;
            foreach (var kvp in linkedList)
            {
                if (kvp.Key.Equals(key))
                {
                    linkedList.Remove(kvp);
                    this.Count -= 1;
                    return true;
                }
            }
        }

        return false;
        //throw new NotImplementedException();
    }

    public void Clear()
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.Select(kvp => kvp.Key);
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.Select(kvp => kvp.Value);
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var elementsLinkedList in this.slots)
        {
            if (elementsLinkedList != null)
            {
                foreach (var kvp in elementsLinkedList)
                {
                    yield return kvp;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
