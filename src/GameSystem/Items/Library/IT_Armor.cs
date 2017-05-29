using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace GameSystem.Items
{
    [ProtoContract]
    public class IT_Armor : IT_Item
    {
        [ProtoMember(1)]
        public int CrushProtection;
        [ProtoMember(2)]
        public int BladeProtection;
        [ProtoMember(3)]
        public int PierceProtection;
        [ProtoMember(4)]
        public int HeatProtection;
        [ProtoMember(5)]
        public int ColdProtection;
        
        [ProtoMember(6)]
        public int IsHeavy;


    }
}
