using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.Items
{
    internal class Stack
    {
        private uint _amount;

        public const uint MAX_STACK_AMOUNT = 50;

        public IT_Item Item { get; private set; }
        public uint Amount
        {
            get
            {
                return _amount;//(Item.IsStackable) ? _amount : 1;
            }
            private set
            {
                if (value > MAX_STACK_AMOUNT)
                {
                    _amount = MAX_STACK_AMOUNT;
                } else { _amount = value; }
            }
        }
        public float FullMass
        {
            get
            {
                return Amount * Item.Mass;
            }
        }

        public Stack(IT_Item item, uint amount)
        {
            Item = item;
            Amount = amount;
        }

        public void RemoveX(uint x)
        {
            Amount -= x;
        }

        public void AddX(uint x)
        {
            Amount += x;
        }

        public static Stack operator +(Stack a, uint b)
        {
            a.AddX(b);

            return a;
        }

        public static Stack operator -(Stack a, uint b)
        {
            a.RemoveX(b);

            return a;
        }
    }
}
