// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
// Copyright (c)2010-2014 Andrew A. Ritz, all rights reserved.
//
// This code is released under the ms-pl (Microsoft Public License)
// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCL.Collections
{

    // ============================================================================================================================
    /// <summary>
    /// This is a lot like a normal dictionary, but both the keys, and the values must be unique.
    /// From there we are allowed to look up the keys that are associated with values, etc.
    /// </summary>
    public class PairDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
    {
        protected List<TKey> _Keys = new List<TKey>();
        protected List<TValue> _Values = new List<TValue>();

        protected IEqualityComparer<TKey> KeyComparer = null;
        protected IEqualityComparer<TValue> ValueComparer = null;

        // --------------------------------------------------------------------------------------------------------------------------
        public PairDictionary()
        { }

        // --------------------------------------------------------------------------------------------------------------------------
        public PairDictionary(IEqualityComparer<TKey> keyComparer_)
        {
            KeyComparer = keyComparer_;
        }

        // --------------------------------------------------------------------------------------------------------------------------
        public PairDictionary(IDictionary<TKey, TValue> source)
            : this()
        {
            foreach (var item in source)
            {
                Add(item.Key, item.Value);
            }
        }

        #region Properties

        public virtual TKey this[TValue index]
        {
            get
            {
                return Key(index);
            }
        }

        public virtual TValue this[TKey index]
        {
            get
            {
                return Value(index);
            }
            set
            {
                SetValue(index, value);
            }
        }

        /// <summary>
        /// The total number of pairs stored in the ditionary.
        /// </summary>
        public int Count
        {
            get { return _Keys.Count; }
        }


        // --------------------------------------------------------------------------------------------------------------------------
        public ReadOnlyCollection<TKey> Keys
        {
            get
            {
                return new ReadOnlyCollection<TKey>(_Keys);
            }
        }

        // --------------------------------------------------------------------------------------------------------------------------
        public ReadOnlyCollection<TValue> Values
        {
            get
            {
                return new ReadOnlyCollection<TValue>(_Values);
            }
        }

        #endregion



        // --------------------------------------------------------------------------------------------------------------------------
        public void Add(TKey key, TValue value)
        {
            ValidateKey(key);
            ValidateValue(value);

            _Keys.Add(key);
            _Values.Add(value);
        }

        // --------------------------------------------------------------------------------------------------------------------------
        private void ValidateValue(TValue value)
        {
            if (_Values.Contains(value, ValueComparer))
            {
                throw new InvalidOperationException(string.Format("The value '{0}' has already been used!", value));
            }
        }

        // --------------------------------------------------------------------------------------------------------------------------
        private void ValidateKey(TKey key)
        {
            if (_Keys.Contains(key, KeyComparer))
            {
                throw new InvalidOperationException(string.Format("The key '{0}' has already been used!", key));
            }
        }

        // --------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns the key for the corresponding value.
        /// </summary>
        public virtual TKey Key(TValue value)
        {
            int index = _Values.IndexOf(value);
            if (index == -1) { throw new KeyNotFoundException(string.Format("could not find matching value!", value)); }

            return _Keys[index];
        }

        // --------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns the value for the corresponding key.
        /// </summary>
        public virtual TValue Value(TKey key)
        {
            int index = GetKeyIndex(key);
            if (index == -1) { throw new KeyNotFoundException(string.Format("could not find matching key '{0}'", key)); }

            return _Values[index];
        }

        // --------------------------------------------------------------------------------------------------------------------------
        public virtual void SetValue(TKey key, TValue newValue)
        {
            // If it isn't there, we can just add and bail.
            int index = GetKeyIndex(key);
            if (index == -1)
            {
                Add(key, newValue);
                return;
            }

            // If it is the same thing, then we will do nothing.
            if (Values[index].Equals(newValue)) { return; }

            ValidateValue(newValue);
            IListHelper.Replace(_Values, index, newValue);
        }

        /// <summary>
        /// Returns the index of the given key, using the comparer, if it is present.
        /// </summary>
        protected int GetKeyIndex(TKey key)
        {
            int index = -1;
            if (KeyComparer != null)
            {
                int len = _Keys.Count;
                for (int i = 0; i < len; i++)
                {
                    if (KeyComparer.Equals(_Keys[i], key))
                    {
                        index = i;
                        break;
                    }
                }
            }
            else
            {
                index = _Keys.IndexOf(key);
            }
            return index;
        }

        // --------------------------------------------------------------------------------------------------------------------------
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var k in _Keys)
            {
                yield return new KeyValuePair<TKey, TValue>(k, Value(k));
            }
        }

        // --------------------------------------------------------------------------------------------------------------------------
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // --------------------------------------------------------------------------------------------------------------------------
        public bool ContainsKey(TKey key)
        {
            return _Keys.Contains(key);
        }

        // --------------------------------------------------------------------------------------------------------------------------
        public bool ContainsValue(TValue value)
        {
            return _Values.Contains(value);
        }

        #region IDictionary Implementation;



        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { throw new NotImplementedException(); }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        // --------------------------------------------------------------------------------------------------------------------------
        // _TEST:
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (_Keys.Contains(item.Key))
            {

                TValue val = this[item.Key];

                if (_Values.Contains(val) && val.Equals(item.Value))
                {
                    _Keys.Remove(item.Key);
                    _Values.Remove(val);
                    return true;
                }
            }
            return false;
        }

        #endregion

    }



    // ============================================================================================================================
    public class DefaultPairDictionary<TKey, TValue> : PairDictionary<TKey, TValue>
    {
        public TKey DefaultKey { get; private set; }
        public TValue DefaultValue { get; private set; }


        // --------------------------------------------------------------------------------------------------------------------------
        public DefaultPairDictionary(TKey defaultKey_, TValue defaultValue_, IEqualityComparer<TKey> keyComparer_)
            : base(keyComparer_)
        {
            InitDefaults(defaultKey_, defaultValue_);
        }

        // --------------------------------------------------------------------------------------------------------------------------
        public DefaultPairDictionary(TKey defaultKey_, TValue defaultValue_)
            : base()
        {
            InitDefaults(defaultKey_, defaultValue_);
        }

        // --------------------------------------------------------------------------------------------------------------------------
        private void InitDefaults(TKey defaultKey_, TValue defaultValue_)
        {
            DefaultKey = defaultKey_;
            DefaultValue = defaultValue_;
        }


        // --------------------------------------------------------------------------------------------------------------------------
        public override TValue Value(TKey key)
        {
            int index = GetKeyIndex(key);
            return index == -1 ? DefaultValue : _Values[index];
        }


        // --------------------------------------------------------------------------------------------------------------------------
        public override TKey Key(TValue value)
        {
            int index = _Values.IndexOf(value);
            return index == -1 ? DefaultKey : _Keys[index];
        }

    }

}