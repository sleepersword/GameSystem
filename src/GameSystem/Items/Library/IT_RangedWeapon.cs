using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace GameSystem.Items
{
    [ProtoContract()]
    public class IT_RangedWeapon : IT_Item
    {
        [ProtoMember(11)]
        public float ChargeTime;
        [ProtoMember(12)]
        public int PierceDamage;
        [ProtoMember(13)]
        public int Precision;
    }
}
