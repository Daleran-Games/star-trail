using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    [CreateAssetMenu(fileName = "NewChoice", menuName = "StarTrail/Choices/Stock Change", order = 2)]
    public class StockChangeChoice : Choice
    {
        [SerializeField]
        private string _stockName;

        [SerializeField]
        private float _amount = 0;

        public override void OnSelected()
        {
            Signals.Raise(new SignalData<float>(Stock.ChangeSignal(_stockName), _amount));
            base.OnSelected();
        }
    } 
}
