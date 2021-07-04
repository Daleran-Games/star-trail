using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DaleranGames.StarTrail
{
    public class Engine : MonoBehaviour
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private Stat _speedStat;

        [SerializeField]
        private float _baseSpeed;
        private Stat.Modifier _speedMod;

        [SerializeField]
        private Stat _fuelBurnRate;

        [SerializeField]
        private float _baseFuelBurnRate;
        private Stat.Modifier _fuelBurnRateMod;

        [SerializeField]
        private FuelTank _fuelTank;

        private Signal _fuelAtMinSig;
        private Signal _fuelChangedSig;

        private void OnEnable()
        {
            _speedMod = new Stat.Modifier(Stat.Modifier.Operand.Base, _baseSpeed, _name);
            _fuelBurnRateMod = new Stat.Modifier(Stat.Modifier.Operand.Base, _baseFuelBurnRate, _name);
            _speedStat.AddModifier(_speedMod);
            _fuelBurnRate.AddModifier(_fuelBurnRateMod);
            _fuelAtMinSig = OnFuelAtMin;
            _fuelChangedSig = OnFuelChanged;
            Signals.Listen(Stock.AtMinSignal("Fuel"), _fuelAtMinSig);
        }

        private void OnDisable()
        {
            _speedStat.RemoveModifier(_speedMod);
            _fuelBurnRate.RemoveModifier(_fuelBurnRateMod);
            Signals.Quiet(Stock.AtMinSignal("Fuel"), _fuelAtMinSig);
        }

        public ISignalData OnFuelAtMin(ISignalData data)
        {
            _speedStat.RemoveModifier(_speedMod);
            _fuelBurnRate.RemoveModifier(_fuelBurnRateMod);
            Signals.Listen(Stock.ChangedSignal("Fuel"), _fuelChangedSig);
            return data;
        }

        public ISignalData OnFuelChanged(ISignalData data)
        {
            var fuel = (SignalData<Stock>)data;

            if (fuel.Data.CurrentValue > 0)
            {
                _speedStat.AddModifier(_speedMod);
                _fuelBurnRate.AddModifier(_fuelBurnRateMod);
                Signals.Quiet(Stock.ChangedSignal("Fuel"), _fuelChangedSig);
            }
            return data;
        }
    }
}