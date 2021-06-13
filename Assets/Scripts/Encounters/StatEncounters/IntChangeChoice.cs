using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    [CreateAssetMenu(fileName = "NewChoice", menuName = "StarTrail/Choices/Int Change", order = 2)]
    public class IntChangeChoice : Choice
    {
        [SerializeField]
        private string _statSignal;

        [SerializeField]
        private int _amount = 0;

        public override void OnSelected()
        {
            Signals.Raise(new SignalData<int>(_statSignal, _amount));
            base.OnSelected();
        }
    } 
}
