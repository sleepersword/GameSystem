using GameSystem.Items;
using System;
using System.Collections.Generic;
using ProtoBuf;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    [ProtoContract(IgnoreListHandling = true)]
    public class Inventory
    {
        private Dictionary<int, Stack> _stacks;

        public float MaximumMass { get; private set; }
        public float CurrentMass
        {
            get
            {
                float mass = 0f;
                foreach (Stack s in _stacks.Values)
                {
                    mass += s.FullMass;
                }
                return mass;
            }
        }
        public bool IsOverloaded
        {
            get { return (CurrentMass > MaximumMass); }
        }

        public int Money;
            
        public Inventory(float maxMass, int money)
        {
            _stacks = new Dictionary<int, Stack>();

            MaximumMass = maxMass;
            Money = money;
        }

        public void AddAmount(int id, uint amount = 1)
        {
            if (ContainsItem(id))
            {
                _stacks[id] += amount;
            }
            else
            {
                _stacks.Add(id, new Items.Stack(IdentityManager.ItemManager.GetItem(id), amount));
            }
        }

        public void AddAmount(IT_Item item, uint amount = 1)
        {
            AddAmount(item.ID, amount);
        }

        public void RemoveAmount(int id, uint amount = 1)
        {
            if (!ContainsItem(id)) throw new Exception("Inventory doesn't contain given Item.");

            if ((_stacks[id].Amount - amount) == 0)
            {
                _stacks.Remove(id);
            } else
            {
                _stacks[id] -= amount;
            }
        }

        public void RemoveAmount(IT_Item item, uint amount = 1)
        {
            RemoveAmount(item.ID, amount);
        }

        public uint GetAmount(int id)
        {
            if (!ContainsItem(id)) throw new Exception("Inventory doesn't contain given Item.");

            return _stacks[id].Amount;
        }

        public uint GetAmount(IT_Item item)
        {
            return GetAmount(item.ID);
        }

        public bool ContainsItem(int id)
        {
            return (_stacks.ContainsKey(id));
        }

        public bool ContainsItem(IT_Item item)
        {
            return ContainsItem(item.ID);
        }

        public void Clear()
        {
            _stacks.Clear();
        }
    }
}
