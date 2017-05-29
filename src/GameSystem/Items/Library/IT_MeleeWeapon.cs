using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace GameSystem.Items
{
    [ProtoContract()]
    public class IT_MeleeWeapon : IT_Item
    {
        [ProtoMember(11)]
        public bool Is2Handed;

        [ProtoMember(12)]
        public int CrushDamage;
        [ProtoMember(13)]
        public int BladeDamage;
        [ProtoMember(14)]
        public int PierceDamage;

        [ProtoMember(15)]
        public float Reach;
    }
}
