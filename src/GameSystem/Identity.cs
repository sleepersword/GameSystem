using GameSystem.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    [ProtoBuf.ProtoContract()]
    [ProtoBuf.ProtoInclude(12, typeof(Character))]
    public abstract class Identity
    {
        [ProtoBuf.ProtoMember(1)]
        public int ID
        {
            get;
            protected set;
        }
    }
}
