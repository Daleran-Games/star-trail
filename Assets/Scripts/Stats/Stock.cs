using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class Stock : MonoBehaviour
    {
        [SerializeField]
        private string _stockName;
        public string StockName { get { return _stockName; } }

        [SerializeField]
        private float _currentValue;

        [SerializeField]
        private List<Flow> _flow;

        public class Flow
        {
            [SerializeField]
            private float _rate;
            public float Rate { get { return _rate; } }

            [SerializeField]
            private string _description;
            public string Description { get { return _description; } }

            public Flow(float rate, string description = "")
            {
                _rate = rate;
                _description = description;
            }
        }

        protected virtual void OnEnable()
        {

        }

        protected virtual void OnDisable()
        {

        }


    } 
}
