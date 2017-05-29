using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace GameSystem
{
    /// <summary>
    /// Stores and manages a list of Skill objects.
    /// </summary>
    [ProtoContract(IgnoreListHandling = true, SkipConstructor = true)]
    public class SkillSet : IEnumerable<Skill>
    {
        /// <summary>
        /// The amount of points to spread among the main skills upon leveling up.
        /// </summary>
        public const int LVLUP_MAINPOINTS = 12;
        /// <summary>
        /// The amount of learnpoints you receive upon leveling up.
        /// </summary>
        public const int LVLUP_LEARNPOINTS = 10;
        /// <summary>
        /// The maximum level a character can reach.
        /// </summary>
        public const int LVL_MAXIMUM = 100;

        [ProtoMember(1, OverwriteList = true)]
        private Dictionary<string, Skill> _skills;

        #region Constructors

        /// <summary>
        /// Initilizes a new SkillLibrary object with the given Skill objects.
        /// Use static method GetDefault to receive a normalized SkillLibrary object.
        /// </summary>
        /// <param name="numberOfSkills">The number of Skill objects given in the next parameter.</param>
        /// <param name="skills">The Skill objects to store in the SkillLibrary.</param>
        public SkillSet(params Skill[] skills)
        {
            _skills = new Dictionary<string, Skill>(skills.Length);
            
            foreach(Skill s in skills)
            {
                _skills.Add(s.Symbol, s);
            }

            Init_EventHandler();
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Returns the absolute amount of XP needed to reach the next level.
        /// </summary>
        /// <returns>The absolute amount of XP.</returns>
        public int XPNeededForNextLevel()
        {
            return XPNeededForLevel(this["lvl"] + 1);
        }

        /// <summary>
        /// Returns or sets the value of the Skill object with the given symbol.
        /// Set is equal to the GetValue method.
        /// </summary>
        /// <param name="t">The symbol of the Skill object.</param>
        /// <returns>The value of the Skill object.</returns>
        public int this[string t]
        {
            get
            {
                if (t.Length != 3) throw new Exception("The given symbol isn't three chars long.");
                if (!_skills.ContainsKey(t)) throw new Exception("The given symbol doesn't exist.");
                return _skills[t].Value;
            }
            set
            {
                if (t.Length != 3) throw new Exception("The given symbol isn't three chars long.");

                _skills[t].Value = value;
            }
        }

        /// <summary>
        /// Sets the value of the Skill object with the given symbol to the given value.
        /// Equal to the paranthesis [] setter.
        /// </summary>
        /// <param name="symbol">The symbol of the Skill object.</param>
        /// <param name="newValue">The new value of the Skill object.</param>
        public void SetValue(string symbol, int newValue)
        {
            this[symbol] = newValue;
        }

        /// <summary>
        /// Returns the value of the Skill object with the given symbol.
        /// Equal to the paranthesis [] getter.
        /// </summary>
        /// <param name="symbol">The symbol of the Skill object.</param>
        /// <returns>The value of the Skill object.</returns>
        public int GetValue(string symbol)
        {
            return this[symbol];
        }

        /// <summary>
        /// Returns the Skill object with the given symbol.
        /// </summary>
        /// <param name="symbol">The symbol of the Skill object.</param>
        /// <returns>The Skill object.</returns>
        public Skill GetSkill(string symbol)
        {
            if (symbol.Length != 3) throw new Exception("The given symbol isn't three chars long.");
            if (!_skills.ContainsKey(symbol)) throw new Exception("The given symbol doesn't exist.");

            return _skills[symbol];
        }

        #endregion

        #region Private Methods

        private void LevelUp()
        {
            if (this["lvl"] == LVL_MAXIMUM) return;

            var e0 = new SkillEventArgs("lvl", this["lvl"], this["lvl"] + 1);
            OnLevelingUp?.Invoke(this, e0);
            if (e0.Abort) return;

            this["lvl"]++;

            #region Handle Mainskills

            float[] spread = SkillSpecificationSpread();
            this["mhp"] += (int)(LVLUP_MAINPOINTS * spread[0]);
            this["mmp"] += (int)(LVLUP_MAINPOINTS * spread[1]);
            this["msp"] += (int)(LVLUP_MAINPOINTS * spread[2]);

            #endregion

            #region Handle Learnpoints

            int lrps = LVLUP_MAINPOINTS;    //Remaining points on lrp
            lrps += -(int)(LVLUP_MAINPOINTS * spread[0]) - (int)(LVLUP_MAINPOINTS * spread[1]) - (int)(LVLUP_MAINPOINTS * spread[2]);

            lrps += LVLUP_LEARNPOINTS;
            if (CentralUtilities.RandomDouble() < (this["lck"] / 100.0) )
            {
                lrps++;
            }
            this["lrp"] += lrps;

            #endregion

            var e1 = new SkillEventArgs("lvl", this["lvl"], this["lvl"]);
            OnLeveledUp?.Invoke(this, e1);

            if (this["xpe"] >= XPNeededForNextLevel())
            {
                LevelUp();
            }
        }

        private float[] SkillSpecificationSpread()
        {
            int sum = this["str"] + this["int"] + this["dex"];

            float str = (float)this["str"] / sum;
            float intl = (float)this["int"] / sum;
            float dex = (float)this["dex"] / sum;

            return new float[] { str, intl, dex };
        }

        [ProtoAfterDeserialization()]
        private void Init_EventHandler()
        {
            _skills["xpe"].OnValueChanged += XP_OnValueChanged;
        }

        private void XP_OnValueChanged(object sender, SkillEventArgs e)
        {
            if (e.NewValue >= XPNeededForNextLevel())
            {
                LevelUp();
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the absolute amount of XP needed to reach the given level.
        /// </summary>
        /// <param name="level">The level for which to calculate the needed XP.</param>
        /// <returns>The absolute amount of XP.</returns>
        public static int XPNeededForLevel(int level)
        {
            if (level > LVL_MAXIMUM)
            {
                return XPNeededForLevel(LVL_MAXIMUM);
            }

            int xp = 10 * level * level + 95 * level;

            return xp;
        }

        /// <summary>
        /// Returns the default skill configuration.
        /// </summary>
        public static SkillSet GetDefault()
        {
            var def = new SkillSet(getDefaultSkills());
            return def;
        }

        private static Skill[] getDefaultSkills()
        {
            List<Skill> res = new List<GameSystem.Skill>(25);

            res.Add(new GameSystem.Skill("lvl", 0, false, false));
            res.Add(new GameSystem.Skill("xpe", 0, true, false));
            res.Add(new GameSystem.Skill("mhp", 100));
            res.Add(new GameSystem.Skill("mmp", 100));
            res.Add(new GameSystem.Skill("msp", 100));

            res.Add(new GameSystem.Skill("str", 10));
            res.Add(new GameSystem.Skill("int", 10));
            res.Add(new GameSystem.Skill("dex", 10));
            res.Add(new GameSystem.Skill("wpw", 10, true, false));

            res.Add(new GameSystem.Skill("ghr", 5));
            res.Add(new GameSystem.Skill("knw", 5));
            res.Add(new GameSystem.Skill("crf", 5));
            res.Add(new GameSystem.Skill("alc", 5));

            res.Add(new GameSystem.Skill("m2h", 0));
            res.Add(new GameSystem.Skill("m1h", 5));
            res.Add(new GameSystem.Skill("rap", 0));
            res.Add(new GameSystem.Skill("nbw", 5));
            res.Add(new GameSystem.Skill("cbw", 0));
            res.Add(new GameSystem.Skill("wnd", 0));
            res.Add(new GameSystem.Skill("dgr", 0));
            res.Add(new GameSystem.Skill("har", 0));
            res.Add(new GameSystem.Skill("lar", 5));
            res.Add(new GameSystem.Skill("rob", 0));

            res.Add(new GameSystem.Skill("lck", 1, true, false));
            res.Add(new GameSystem.Skill("lrp", 0, true, false));

            return res.ToArray();
        }

        #endregion

        #region Implementations

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------------");

            string[] symbols = _skills.Keys.ToArray<string>();

            for (int i = 0; i < symbols.Length; i += 2)
            {
                string num = this[symbols[i]].ToString();
                while (num.Length < 4) { num = num.Insert(0, " "); }
                if (num.Length > 4) { num = num.Substring(0, 4); }

                sb.Append("| " + symbols[i] + " | " + num + " |");


                if (i + 1 < symbols.Length)
                {
                    string num1 = this[symbols[i + 1]].ToString();
                    while (num1.Length < 4) { num1 = num1.Insert(0, " "); }
                    if (num1.Length > 4) { num1 = num1.Substring(0, 4); }

                    sb.Append(" " + symbols[i + 1] + " | " + num1 + " |");
                }

                sb.AppendLine();
            }

            sb.AppendLine("---------------------------");

            return sb.ToString();
        }

        public IEnumerator<Skill> GetEnumerator()
        {
            foreach (Skill i in _skills.Values)
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

        #region Events

        public event SkillEventHandler OnLevelingUp;
        public event SkillEventHandler OnLeveledUp;

        #endregion
    }
}
