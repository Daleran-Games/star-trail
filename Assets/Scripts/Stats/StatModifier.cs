using System.Collections;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    [System.Serializable]
    public class StatModifier
    {
        public enum Operand
        {
            Base,
            Additive,
            Multiplicative
        }

        [SerializeField]
        private Operand _operation;
        public Operand Operation { get{ return _operation; } }

        [SerializeField]
        private float _amount;
        public float Amount { get { return _amount; } }

        [SerializeField]
        private string _description;
        public string Description { get { return _description; } }

        public StatModifier(Operand operation, float amount, string description = "")
        {
            _operation = operation;
            _amount = amount;
            _description = description;
        }
    }
}