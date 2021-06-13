using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DaleranGames.StarTrail
{
    public class Engine : MonoBehaviour
    {
        [SerializeField]
        private StatModifier _speed = new StatModifier(StatModifier.Operand.Base, 1f, "Engine Mark 1");

        [SerializeField]
        private StatModifier _fuelBurnRate = new StatModifier(StatModifier.Operand.Base, 1f, "Engine Mark 1");

        [SerializeField]
        private string _description = "Engine Mark 1";

        private StatCalculator _statCalculator = new StatCalculator();

        private void OnEnable()
        {
            Signals.Listen("StatSpeed", OnStatSpeed, 100);
            Signals.Listen("StatSpeed", OnStatSpeedCalc, 300);
            Signals.Listen("StatFuelBurnRate", OnStatFuelBurnRate, 100);
            Signals.Listen("StatFuelBurnRate", OnStatFuelBurnRateCalc, 300);

        }

        public ISignalData OnStatSpeed(ISignalData data)
        {
            var statMods = (StatModifierSignal)data;
            statMods.AddModifier(_speed);
            statMods.Description = _description;
            return data;
        }

        public ISignalData OnStatSpeedCalc(ISignalData data)
        {
            return _statCalculator.Calculate((StatModifierSignal)data);
        }

        public ISignalData OnStatFuelBurnRate(ISignalData data)
        {
            var statMods = (StatModifierSignal)data;
            statMods.AddModifier(_fuelBurnRate);
            statMods.Description = _description;
            return data;
        }

        public ISignalData OnStatFuelBurnRateCalc(ISignalData data)
        {
            return _statCalculator.Calculate((StatModifierSignal)data);
        }
    }
}