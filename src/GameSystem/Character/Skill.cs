using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace GameSystem
{
    /// <summary>
    /// Describes a skill as a combination of a string symbol and an integer value.
    /// </summary>
    [ProtoContract(IgnoreListHandling = true, SkipConstructor = true)]
    public class Skill
    {
        [ProtoMember(1)]
        private string _symbol;
        [ProtoMember(2)]
        internal int _value;
        [ProtoMember(3, OverwriteList = true)]
        private Dictionary<string, int> _boni;

        /// <summary>
        /// Determines if this Skill object should fire its events. Default: true
        /// </summary>
        [ProtoMember(4)]
        public bool FireEvents;
        /// <summary>
        /// Determines if the bonuses are enabled. Default: true
        /// </summary>
        [ProtoMember(5)]
        public bool EnableBoni;

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }
        public int Value
        {
            get { return (EnableBoni) ? ApplyBonuses() : _value; }
            set
            {
                var e = new SkillEventArgs(Symbol, _value, value);
                if (FireEvents) OnValueChanging?.Invoke(this, e);
                if (e.Abort) return;

                _value = value;

                var e1 = new SkillEventArgs(Symbol, _value, value);
                if (FireEvents) OnValueChanged?.Invoke(this, e1);
            }
        }

        #region Constructors

        public Skill() : this("dft", 0)
        {
            return;
        }

        public Skill(string sym, int value, bool fireEvents = true, bool enableBonuses = true)
        {
            _symbol = sym;
            _value = value;

            FireEvents = fireEvents;
            EnableBoni = enableBonuses;

            _boni = new Dictionary<string, int>();
        }

        #endregion

        #region Public Methods

        public void SetBonus(string bonusName, int value)
        {
            if (_boni.ContainsKey(bonusName)) throw new Exception("The given bonus already exists in this skill.");

            var e0 = new SkillEventArgs(bonusName, 0, value);
            if (FireEvents) OnSettingBonus?.Invoke(this, e0);
            if (e0.Abort) return;

            _boni.Add(bonusName, value);

            var e1 = new SkillEventArgs(Symbol, Value, Value);
            if (FireEvents) OnValueChanged?.Invoke(this, e1);
        }
        
        public void UnsetBonus(string bonusName)
        {
            if (!_boni.ContainsKey(bonusName)) throw new Exception("The given bonus doesn't exist in this skill.");

            var e0 = new SkillEventArgs(bonusName, GetBonus(bonusName), 0);
            if (FireEvents) OnUnsettingBonus?.Invoke(this, e0);
            if (e0.Abort) return;

            _boni.Remove(bonusName);

            var e1 = new SkillEventArgs(Symbol, Value, Value);
            if (FireEvents) OnValueChanged?.Invoke(this, e1);
        }

        public int GetBonus(string bonusName)
        {
            return _boni[bonusName];
        }

        public bool ContainsBonus(string bonusName)
        {
            return _boni.ContainsKey(bonusName);
        }

        public string[] GetBoniNames()
        {
            if (!EnableBoni) return new string[0];

            return _boni.Keys.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}::{1}]", Symbol, Value);
        }

        #endregion

        #region Private Methods

        private int ApplyBonuses()
        {
            if (!EnableBoni || _boni.Count == 0) return _value;

            int res = _value;
            foreach (int b in _boni.Values)
            {
                res += b;
            }

            return res;
        }

        [ProtoBeforeDeserialization()]
        private void BeforeDeserialization()
        {
            _boni = new Dictionary<string, int>();
        }

        #endregion

        #region Events

        public event SkillEventHandler OnValueChanging;
        public event SkillEventHandler OnValueChanged;
        public event SkillEventHandler OnSettingBonus;
        public event SkillEventHandler OnUnsettingBonus;

        #endregion
    }
}
