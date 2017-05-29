using System;

namespace GameSystem
{
    /// <summary>
    /// Contains information about a Skill object that is changing or changed.
    /// </summary>
    public class SkillEventArgs : EventArgs
    {
        /// <summary>
        /// The symbol of the Skill object.
        /// </summary>
        public string SkillSymbol;
        /// <summary>
        /// The old value of the Skill object.
        /// </summary>
        public int OldValue;
        /// <summary>
        /// The new value of the Skill object.
        /// </summary>
        public int NewValue;
        /// <summary>
        /// Indicating if the value of the Skill object should remain unchanged.
        /// Only affects "changing" events.
        /// Default false.
        /// </summary>
        public bool Abort = false;

        public SkillEventArgs(string symbol, int oldValue, int newValue)
        {
            SkillSymbol = symbol;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public delegate void SkillEventHandler(object sender, SkillEventArgs e);
}
