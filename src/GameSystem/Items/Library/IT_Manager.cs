using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ProtoBuf;
using System.Threading.Tasks;
using System.Collections;

namespace GameSystem.Items
{
    public class IT_Manager : IDisposable, IEnumerable<IT_Item>
    {
        #region Private Fields
        private Dictionary<int, IT_Item> _items;
        #endregion

        #region Public Fields
        public int Count
        {
            get
            { return _items.Count; }
        }
        #endregion

        internal IT_Manager()
        {
            _items = new Dictionary<int, IT_Item>();
        }

        public void AddItem(IT_Item item)
        {
            var id = item.ID;
            if (ContainsItem(id)) throw new IDAlreadyExistsException(_items[id], item);

            _items.Add(id, item);
        }

        public void RemoveItem(int id)
        {
            if (!ContainsItem(id)) throw new IDDoesntExistsException(id);

            _items.Remove(id);
        }

        public void RemoveItem(IT_Item item)
        {
            RemoveItem(item.ID);
        }

        public IT_Item GetItem(int id)
        {
            if (ContainsItem(id)) return _items[id];
            else throw new IDDoesntExistsException(id);
        }

        public void Clear()
        {
            _items.Clear();
        }

        //Checks for validity of ID
        public bool ContainsItem(int id)
        {
            if (!IdentityManager.ValidateFullID(id)) throw new Exception("ID isn't valid.");

            return _items.ContainsKey(id);
        }

        public bool ContainsItem(IT_Item item)
        {
            return ContainsItem(item.ID);
        }

        #region Help methods

        internal int[] GetAllIDs()
        {
            return _items.Keys.ToArray<int>();
        }

        internal void AddSet(IT_Set set)
        {
            foreach (IT_Item t in set.Items)
            {
                AddItem(t);
            }
        }

        internal void RemoveSet(IT_Set set)
        {
            foreach (IT_Item t in set.Items)
            {
                RemoveItem(t.ID);
            }
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    _items = null;
                }
                
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion

        #region IEnumerable Support

        public IEnumerator<IT_Item> GetEnumerator()
        {
            foreach (IT_Item i in _items.Values)
            {
                if (i == null) break;

                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }


    public class IDAlreadyExistsException : Exception
    {

        public Identity NewItem;
        public Identity OldItem;
        public int SharedID;

        public IDAlreadyExistsException(Identity old, Identity ne)
        {
            OldItem = old;
            NewItem = ne;

            SharedID = OldItem.ID;
        }
    }

    public class IDDoesntExistsException : Exception
    {
        public int ID;

        public IDDoesntExistsException(int id)
        {
            ID = id;
        }
    }
}
