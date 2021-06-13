using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public abstract class RuntimeSet<T> : ScriptableObject, ICollection<T>
    {
        [SerializeField]
        List<T> items = new List<T>();

        public T this[int index]
        {
            get { return items[index]; }
        }

        public int Count { get { return items.Count; } }
        public bool IsReadOnly { get { return false; } }

        public Action SetModified;

        public void Add(T thing)
        {
            if (!items.Contains(thing))
                items.Add(thing);

            SetModified?.Invoke();
        }

        public void Clear()
        {
            items.Clear();
            SetModified?.Invoke();
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void Remove(T thing)
        {
            if (items.Contains(thing))
                items.Remove(thing);

            SetModified?.Invoke();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        bool ICollection<T>.Remove(T item)
        {
            if (items.Remove(item))
            {
                SetModified?.Invoke();
                return true;
            }
            return false;
        }
    }
}

