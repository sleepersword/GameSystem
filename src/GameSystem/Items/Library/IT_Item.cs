using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using System.IO;

namespace GameSystem.Items
{
    [ProtoContract]
    public class IT_Item : Identity
    {
        [ProtoMember(2)]
        public IT_Types Type;
        [ProtoMember(3)]
        public string Name;
        [ProtoMember(4)]
        public int Value;
        [ProtoMember(5)]
        public float Mass;
        [ProtoMember(6)]
        public bool IsSellable;
        [ProtoMember(7)]
        public bool IsDestroyable;
        [ProtoMember(8)]
        public bool IsDamaged;
        [ProtoMember(9)]
        public bool IsStackable;
        [ProtoMember(10)]
        public Requirement[] Requirements;

        public int NumberOfInstances;

        public IT_Item(int id, IT_Types type, string name, int value, float mass, bool sellable, bool destroyable, bool damaged, bool stackable,params Requirement[] requs)
        {
            ID = id;
            Type = type;
            Name = name;
            Value = value;
            Mass = mass;
            IsDestroyable = destroyable;
            IsSellable = sellable;
            IsDamaged = damaged;
            IsStackable = stackable;
            Requirements = requs;

            NumberOfInstances = 0;
        }

        public IT_Item()
        {
            ID = 0;
            Name = "Default";
            Type = IT_Types.Miscellaneous;
            Value = 0;
            Mass = 0;
            IsDestroyable = true;
            IsSellable = true;
            IsDamaged = false;
            IsStackable = true;
            Requirements = null;
        }

        public IT_Item Copy(int newID)
        {
            return new IT_Item(newID, Type, Name, Value, Mass, IsSellable, IsDestroyable, IsDamaged, IsStackable , Requirements );
        }

        public override string ToString()
        {
            return (ID + ":" + Name + ">" + Type + "<[" +
                "Value=" + Value + ";Mass=" + Mass + ";IsSellable=" + IsSellable + ";IsDestroyable=" + IsDestroyable + ";IsStackable=" + IsStackable +"]");
        }
    }
}
