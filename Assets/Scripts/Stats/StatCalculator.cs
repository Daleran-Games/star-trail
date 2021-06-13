using System.Collections;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class StatCalculator
    {
        public bool Round { get; private set; }

        public StatCalculator(bool round = true)
        {
            Round = round;
        }

        public virtual StatModifierSignal Calculate(StatModifierSignal mods)
        {
            float baseVal = 0f;
            float toAdd = 0f;
            float toMultiply = 1f;
            foreach(StatModifier mod in mods.Modifiers)
            {
                if (mod.Operation == StatModifier.Operand.Base)
                {
                    if (baseVal != 0)
                    {
                        Debug.LogWarning("Multiple base values detected. Stat: " 
                            + mods.SignalName
                            + " Modifier: "
                            + mod.Description);
                    }
                    
                    baseVal = mod.Amount;
                }
                else if(mod.Operation == StatModifier.Operand.Additive)
                {
                    toAdd += mod.Amount;
                } else if (mod.Operation == StatModifier.Operand.Multiplicative)
                {
                    toMultiply += mod.Amount;
                }
            }

            if (Round)
            {
                mods.FinalValue = Mathf.Round((baseVal + toAdd) * toMultiply);
            } else
            {
                mods.FinalValue = (baseVal + toAdd) * toMultiply;
            }
          
            return mods;
        }
    }
}