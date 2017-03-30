using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.Models
{
    class InventoryList : IList<Inventory>, INotifyCollectionChanged
    {
        public IEnumerator<Inventory> GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _inventories.GetEnumerator();

        public void Add(Inventory item)
        {
            _inventories.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void Clear()
        {
            _inventories.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(Inventory item) => _inventories.Contains(item);

        public void CopyTo(Inventory[] array, int arrayIndex)
        {
            _inventories.CopyTo(array, arrayIndex);
        }

        public bool Remove(Inventory item)
        {
            var removed = _inventories.Remove(item);
            if (removed)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Remove, item));
            }
            return removed;
        }

        public int Count => _inventories.Count;
        public bool IsReadOnly => _inventories.IsReadOnly;

        public int IndexOf(Inventory item) => _inventories.IndexOf(item);

        public void Insert(int index, Inventory item)
        {
            _inventories.Insert(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        public void RemoveAt(int index)
        {
            var itm = _inventories[index];
            _inventories.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
            NotifyCollectionChangedAction.Remove, itm, index));
        }

        public Inventory this[int index]
        {
            get { return _inventories?[index]; }
            set
            {
                _inventories[index] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Replace, _inventories[index]));
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
        }

        private readonly IList<Inventory> _inventories;
        public InventoryList(IList<Inventory> inventories)
        {
            _inventories = inventories;
        }
    }
}
