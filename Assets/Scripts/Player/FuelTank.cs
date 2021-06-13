using System.Collections;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class FuelTank : MonoBehaviour
    {
        [SerializeField]
        private float _fuelPerDay = 1f;

        [SerializeField]
        private float _currentFuel = 10f;

        [SerializeField]
        private float _maxFuel = 10f;

        // Use this for initialization
        void OnEnable()
        {
            Signals.Listen("StartOfDay", OnStartOfDay);
            Signals.Listen("ChangeFuel", OnChangeFuel);
        }

        public ISignalData OnStartOfDay(ISignalData data)
        {
            var newDay = (SignalData<int>)data;
            _currentFuel -= _fuelPerDay;

            if (_currentFuel < 1)
            {
                _currentFuel = 0;
                Signals.Raise(new SignalData<FuelTank>("OutOfFuel", this));
            }
            return data;
        }

        public ISignalData OnChangeFuel(ISignalData data)
        {
            var amount = (SignalData<int>)data;
            AddFuel(amount.Data);
            return data;
        }

        // TODO: Needs testing
        public void AddFuel (int amount)
        {
            _currentFuel += amount;
            if (_currentFuel > _maxFuel)
            {
                _currentFuel = _maxFuel;
            }
        }
    }
}