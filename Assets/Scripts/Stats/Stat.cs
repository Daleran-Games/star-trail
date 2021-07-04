using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class Stat : MonoBehaviour
    {
        [SerializeField]
        private string _id;
        public string Id { get { return _id; } }

        

        [SerializeField]
        private float _currentValue;
        private float _previousValue;
        public float CurrentValue { get { return _currentValue; } }

        [SerializeField]
        private bool _round = true;
        public bool Round { get { return _round; } }

        [SerializeField]
        private List<Modifier> _modifiers;
        public List<Modifier> Modifiers { get { return _modifiers; } }

        private Signal _getStatSig;
        private Signal _addModSig;
        private Signal _removeModSig;

        // Listened
        public static string GetSignal(string id) { return $"Stat{id}Get"; }
        public static string AddModSignal(string id) { return $"Stat{id}AddMod"; }
        public static string RemoveModSignal(string id) { return $"Stat{id}RemoveMod"; }

        // Raised
        public static string ModifiedSignal(string id) { return $"Stock{id}Modified"; }

        [Serializable]
        public class Modifier: IEquatable<Modifier>, IComparable<Modifier>, IComparable
        {
            public enum Operand
            {
                Base,
                Additive,
                Multiplicative
            }

            [SerializeField]
            private Operand _operation;
            public Operand Operation { get { return _operation; } }

            [SerializeField]
            private float _amount;
            public float Amount { get { return _amount; } }

            [SerializeField]
            private string _description;
            public string Description { get { return _description; } }

            public Modifier(Operand operation, float amount, string description = "")
            {
                _operation = operation;
                _amount = amount;
                _description = description;
            }

            public bool Equals(Modifier other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.Operation == Operation && other.Amount == Amount && other.Description == Description;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == typeof(Modifier) && Equals((Modifier)obj);
            }

            public int CompareTo(Modifier other)
            {
                if (other.Operation == Operation)
                {
                    return Amount.CompareTo(other.Amount);
                }
                else
                {
                    return Operation.CompareTo(other.Operation);
                }
            }

            public int CompareTo(object obj)
            {
                if (ReferenceEquals(null, obj)) return 1;
                if (ReferenceEquals(this, obj)) return 0;

                if (obj.GetType() == typeof(Modifier) && Equals((Modifier)obj))
                    return CompareTo((Modifier)obj);
                else
                    throw new ArgumentException("Object is not a Modifer");
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Description.GetHashCode()) ^ Amount.GetHashCode();
                }
            }

            public static bool operator ==(Modifier lhs, Modifier rhs) => lhs.Equals(rhs);

            public static bool operator !=(Modifier lhs, Modifier rhs) => !(lhs == rhs);
        }

        protected virtual void OnEnable()
        {
            _currentValue = Calculate();
            _getStatSig = OnGetStat;
            _addModSig = OnAddMod;
            _removeModSig = OnRemoveMod;
            Signals.Listen(GetSignal(_id), _getStatSig);
            Signals.Listen(AddModSignal(_id), _addModSig);
            Signals.Listen(RemoveModSignal(_id), _removeModSig);
        }

        protected virtual void OnDisable()
        {
            Signals.Quiet(GetSignal(_id), _getStatSig);
            Signals.Quiet(AddModSignal(_id), _addModSig);
            Signals.Quiet(RemoveModSignal(_id), _removeModSig);
        }

        private ISignalData OnGetStat(ISignalData data)
        {
            return new SignalData<Stat>(GetSignal(_id), this);
        }

        private ISignalData OnAddMod(ISignalData data)
        {
            var mod = (SignalData<Modifier>)data;
            AddModifier(mod.Data);
            return data;
        }

        private ISignalData OnRemoveMod(ISignalData data)
        {
            var mod = (SignalData<Modifier>)data;
            RemoveModifier(mod.Data);
            return data;
        }

        public void AddModifier(Modifier mod)
        {
            _previousValue = _currentValue;
            _modifiers.Add(mod);
            _currentValue = Calculate();
            Signals.Raise(new SignalData<Stat>(ModifiedSignal(_id), this));
        }

        public void RemoveModifier(Modifier mod)
        {
            _previousValue = _currentValue;
            _modifiers.Remove(mod);
            _currentValue = Calculate();
            Signals.Raise(new SignalData<Stat>(ModifiedSignal(_id), this));
        }

        public virtual float Calculate()
        {
            float baseVal = 0f;
            float toAdd = 0f;
            float toMultiply = 1f;
            foreach (Modifier mod in Modifiers)
            {
                if (mod.Operation == Modifier.Operand.Base)
                {
                    if (baseVal != 0)
                    {
                        Debug.LogWarning($"Multiple base values detected. Stat: {Id} Modifier: {mod.Description}");
                    }

                    baseVal = mod.Amount;
                }
                else if (mod.Operation == Modifier.Operand.Additive)
                {
                    toAdd += mod.Amount;
                }
                else if (mod.Operation == Modifier.Operand.Multiplicative)
                {
                    toMultiply += mod.Amount;
                }
            }

            if (Round)
            {
                return Mathf.Round((baseVal + toAdd) * toMultiply);
            }
            return (baseVal + toAdd) * toMultiply;
        }
    } 
}
