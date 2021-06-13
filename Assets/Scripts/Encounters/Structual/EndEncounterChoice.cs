using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    [CreateAssetMenu(fileName = "NewChoice", menuName = "StarTrail/Choices/End Encounter", order = 3)]
    public class EndEncounterChoice : Choice
    {
        public override void OnSelected()
        {
            Signals.Raise(new SignalData<Choice>("EncounterEnd", this));
            base.OnSelected();
        }
    }
}