using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class Stock : MonoBehaviour
    {
        [SerializeField]
        protected string _id;
        public string Id { get { return _id; } }

        [SerializeField]
        protected float _currentValue;
        public float CurrentValue { get { return _currentValue; } }

        public float Min
        {
            get
            {
                return 0f;
            }
        }

        [SerializeField]
        protected Stat _maxStat;
        public float Max
        {
            get
            {
                if (_maxStat != null)
                {
                    return _maxStat.CurrentValue;
                }
                return 0f;
            }
        }

        [SerializeField]
        protected Stat _flowRate;

        private Signal _getStockSig;
        private Signal _calculateFlows;
        private Signal _changeSig;

        // Listened
        public static string GetSignal(string id) { return $"Stock{id}Get"; }
        public static string ChangeSignal(string id) { return $"Stock{id}Change"; }

        // Raised
        public static string ChangedSignal(string id) { return $"Stock{id}Changed"; }
        public static string AtMinSignal(string id) { return $"Stock{id}AtMin"; }
        public static string AtMaxSignal(string id) { return $"Stock{id}AtMax"; }

        protected virtual void OnEnable()
        {
            _getStockSig = OnGetStock;
            _changeSig = OnChange;
            Signals.Listen(GetSignal(_id), _getStockSig);
            Signals.Listen(ChangeSignal(_id), _changeSig);

            if(_flowRate != null)
            {
                _calculateFlows = OnCalculateFlows;
                Signals.Listen("StartOfDay", _calculateFlows);
            }
        }

        protected virtual void OnDisable()
        {
            Signals.Quiet(GetSignal(_id), _getStockSig);
            Signals.Quiet(ChangeSignal(_id), _changeSig);

            if (_flowRate != null)
            {
                Signals.Quiet("StartOfDay", _calculateFlows);
            }
        }

        private ISignalData OnGetStock(ISignalData data)
        {
            return new SignalData<Stock>(GetSignal(_id), this);
        }

        private ISignalData OnCalculateFlows(ISignalData data)
        {
            Change(_flowRate.CurrentValue);
            return data;
        }

        private ISignalData OnChange(ISignalData data)
        {
            var change = (SignalData<float>)data;
            var amount = Change(change.Data);
            return new SignalData<float>(ChangedSignal(_id), amount);
        }

        public float Change(float amount)
        {
            float _initialValue = _currentValue;
            _currentValue += amount;
            if (_currentValue <= Min)
            {
                _currentValue = Min;
                Signals.Raise(new SignalData<Stock>(AtMinSignal(_id), this));
            } else if (_currentValue >= Max)
            {
                _currentValue = Max;
                Signals.Raise(new SignalData<Stock>(AtMaxSignal(_id), this));
            }

            Signals.Raise(new SignalData<Stock>(ChangedSignal(_id), this));
            return _initialValue - _currentValue;
        }
    } 
}
