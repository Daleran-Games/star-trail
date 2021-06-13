using System.Collections;
using System.Collections.Generic;

namespace DaleranGames.StarTrail
{
    public class StatModifierSignal : ISignalData
    {
        public string SignalName { get; private set; }
        public float FinalValue { get; set; }
        public string Description { get; set; }

        public List<StatModifier> Modifiers { get; set; }

        public StatModifierSignal(string statName, string description = "")
        {
            SignalName = "Stat" + statName;
            Description = description;
            Modifiers = new List<StatModifier>();
        }

        public void AddModifier(StatModifier modifier)
        {
            Modifiers.Add(modifier);
        }

        public string[] GetDescriptions()
        {
            List<string> _descs = new List<string>();
            if (Description != "")
            {
                _descs.Add(Description);
            }
            
            foreach(StatModifier mod in Modifiers)
            {
                if (mod.Description != "")
                {
                    _descs.Add(mod.Description);
                }
            }

            return _descs.ToArray();
        }
    }
}