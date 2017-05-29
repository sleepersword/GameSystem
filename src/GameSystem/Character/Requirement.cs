using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProtoBuf;

namespace GameSystem
{
    /// <summary>
    /// Represents a requirement to perform an unspecified task.
    /// Is treated as a comparision of a value to a skill.
    /// </summary>
    [ProtoContract]
    public class Requirement
    {
        /// <summary>
        /// The char that separates multiple requirements
        /// </summary>
        public const char SEPARATOR = ';';

        [ProtoMember(1)]
        public string Symbol;
        [ProtoMember(2)]
        public RequirementOperator Operator;
        [ProtoMember(3)]
        public int Value;

        #region Constructors

        /// <summary>
        /// Initalizes a Requirement object to the given values.
        /// </summary>
        /// <param name="symbol">The symbol of the skill.</param>
        /// <param name="op">The type of comparison.</param>
        /// <param name="value">The required value of the skill.</param>
        public Requirement(string symbol, RequirementOperator op, int value)
        {
            Symbol = symbol;
            Operator = op;
            Value = value;
        }

        /// <summary>
        /// Initializes a Requirement object from a given string.
        /// Use the static FromString Method if the string contains multiple requirements.
        /// </summary>
        /// <param name="input">The string representing the requirement.</param>
        public Requirement(string input)
        {
            var match = Regex.Match(input, @" *(?<property>[a-z0-9]{3})(?<operator>==|\>=|\<=|\>\>|\<\<)(?<value>[0-9]+) *");

            Symbol = match.Groups["property"].Value;
            Operator = OpFromString(match.Groups["operator"].Value);
            Value = int.Parse(match.Groups["value"].Value);
        }

        /// <summary>
        /// The default constructor. Corresponds to the "dft" equals 0.
        /// </summary>
        public Requirement()
        {
            Symbol = "dft";
            Operator = RequirementOperator.Equal;
            Value = 0;
        }

        #endregion

        #region Public Methods

        public bool CheckRequirement(SkillSet skills)
        {
            int charValue = skills[Symbol];

            switch (Operator)
            {
                case RequirementOperator.Equal:
                    return (charValue == Value);
                case RequirementOperator.EqualOrGreater:
                    return (charValue >= Value);
                case RequirementOperator.EqualOrSmaller:
                    return (charValue <= Value);
                case RequirementOperator.Greater:
                    return (charValue > Value);
                case RequirementOperator.Smaller:
                    return (charValue < Value);
            }

            return false;
        }

        public override string ToString()
        {
            return (Symbol + OpToString(Operator) + Value + SEPARATOR);
        }

        #endregion

        #region Static Methods

        public static Requirement[] FromString(string seq)
        {
            var split = seq.Split(new char[] { SEPARATOR }, 99, StringSplitOptions.RemoveEmptyEntries);
            Requirement[] res = new Requirement[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] != "")
                {
                    res[i] = new GameSystem.Requirement(split[i]);
                }
            }

            return res;
        }

        public static string ToString(Requirement[] requs)
        {
            if (requs == null) return "";

            StringBuilder res = new StringBuilder(16);

            foreach(var r in requs)
            {
                res.Append(r.ToString());
            }

            return res.ToString();
        }

        #endregion

        #region RequirementOperator Enumeration

        public enum RequirementOperator
        {
            Equal,
            EqualOrGreater,
            EqualOrSmaller,
            Greater,
            Smaller
        }

        public static RequirementOperator OpFromString(string inp)
        {
            switch (inp)
            {
                case "==":
                    return RequirementOperator.Equal;

                case ">=":
                    return RequirementOperator.EqualOrGreater;

                case "<=":
                    return RequirementOperator.EqualOrSmaller;

                case ">>":
                    return RequirementOperator.Greater;

                case "<<":
                    return RequirementOperator.Smaller;

                default:
                    return RequirementOperator.Equal;
            }
        }

        public static string OpToString(RequirementOperator op)
        {
            switch (op)
            {
                case RequirementOperator.Equal:
                    return "==";

                case RequirementOperator.EqualOrGreater:
                    return ">=";

                case RequirementOperator.EqualOrSmaller:
                    return "<=";

                case RequirementOperator.Greater:
                    return ">>";

                case RequirementOperator.Smaller:
                    return "<<";

                default:
                    return "==";
            }
        }

        #endregion
    }

}
