using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace GameSystem
{
    /// <summary>
    /// Describes an ingame character.
    /// </summary>
    [ProtoContract(SkipConstructor = true)]
    public class Character : Identity
    {
        [ProtoMember(1)]
        public string Name;
        [ProtoMember(2)]
        public SkillSet Skills;

        public int Level
        {
            get
            {
                return Skills["lvl"];
            }
        }

        #region Constructors

        public Character(int id, string name)
        {
            ID = id;
            Name = name;

            Skills = SkillSet.GetDefault();
        }

        public Character(int id, string name, params Skill[] skills)
        {
            if (skills.Length < 1) throw new Exception();

            Name = name;
            ID = id;

            Skills = new GameSystem.SkillSet(skills);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the xpe Skill to the value returned bei Skills.XPNeededForNextLevel
        /// </summary>
        public void LevelUpManually()
        {
            Skills["xpe"] = Skills.XPNeededForNextLevel();
        }

        public override string ToString()
        {
            return string.Format("{0} CHARACTER {1} | LVL {2}", ID, Name, Level);
        }

        #endregion

        public static void Serialize(Character ch, System.IO.Stream st)
        {
            Serializer.Serialize<Character>(st, ch);
        }

        public static Character Deserialize(System.IO.Stream st)
        {
            return Serializer.Deserialize<Character>(st);
        }
    }
}
