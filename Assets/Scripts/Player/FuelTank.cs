using System.Collections;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class FuelTank : Stock
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private float _baseMaxFuel;
        private Stat.Modifier _maxFuelMod;

        protected override void OnEnable()
        {
            base.OnEnable();
            _maxFuelMod = new Stat.Modifier(Stat.Modifier.Operand.Base, _baseMaxFuel, _name);
            _maxStat.AddModifier(_maxFuelMod);
            Change(_maxStat.CurrentValue);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _maxStat.RemoveModifier(_maxFuelMod);
        }
    }
}