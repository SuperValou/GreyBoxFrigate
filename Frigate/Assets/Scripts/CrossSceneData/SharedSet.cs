using System;
using System.Collections.Generic;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.CrossSceneData
{
    public class SharedSet<T> : ScriptableObject
    {
        private readonly ICollection<T> _items = new HashSet<T>();
        public event Action<T> ItemAdded;
        public event Action<T> ItemRemoved;

        public ICollection<T> Items => new List<T>(_items);

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_items.Contains(item))
            {
                throw new InvalidOperationException($"Item '{item}' cannot be added to '{this.name}' ({nameof(SharedSet<T>)}) " +
                                                    $"because it is already present.");
            }

            _items.Add(item);
            ItemAdded.SafeInvoke(item);
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!_items.Contains(item))
            {
                throw new InvalidOperationException($"Item '{item}' cannot be removed from '{this.name}' ({nameof(SharedSet<T>)}) " +
                                                    $"because it was not present in the first place.");
            }

            _items.Remove(item);
            ItemRemoved.SafeInvoke(item);
        }

        void OnDisable()
        {
            if (_items.Count == 0)
            {
                return;
            }

            Debug.LogError($"{this.name} ({this.GetType().Name}) is being disabled, but {_items.Count} {typeof(T).Name}(s) are still referenced. " +
                           $"Did you forgot some calls to the {nameof(Remove)} method?");
            _items.Clear();
        }
    }
}