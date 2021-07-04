using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public delegate ISignalData Signal(ISignalData data);

    public static class Signals
    {
        private static Dictionary<string, PriorityList<SignalPriorityWrapper>> _signals = new Dictionary<string, PriorityList<SignalPriorityWrapper>>();

        private class SignalPriorityWrapper : IPrioritizable, IEquatable<SignalPriorityWrapper>
        {
            public int Priority { get; private set; }
            public Signal Signal { get; private set; }

            public SignalPriorityWrapper(Signal Signal, int priority)
            {
                this.Signal = Signal;
                Priority = priority;
            }

            public bool Equals(SignalPriorityWrapper other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.Signal == Signal && other.Priority == Priority;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == typeof(SignalPriorityWrapper) && Equals((SignalPriorityWrapper)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Signal.GetHashCode()) ^ Priority.GetHashCode();
                }
            }

            public static bool operator ==(SignalPriorityWrapper lhs, SignalPriorityWrapper rhs) => lhs.Equals(rhs);

            public static bool operator !=(SignalPriorityWrapper lhs, SignalPriorityWrapper rhs) => !(lhs == rhs);
        }

        public static void Listen(string signalName, Signal signal, int priority =10)
        {
            if(!_signals.ContainsKey(signalName))
            {
                _signals.Add(signalName, new PriorityList<SignalPriorityWrapper>());
            }
            var hookList = _signals[signalName];
            hookList.Add(new SignalPriorityWrapper(signal, priority));
        }

        public static void Quiet(string signalName, Signal signal, int priority = 10)
        {
            if (!_signals.ContainsKey(signalName))
            {
                return;
            }
            var hookList = _signals[signalName];
            hookList.Remove(new SignalPriorityWrapper(signal, priority));
        }

        public static ISignalData Raise(ISignalData data)
        {
            if (!_signals.ContainsKey(data.SignalName))
            {
                return data;
            }
            var hookList = _signals[data.SignalName];
            ISignalData result = data;

            // We iterate over an isolated copy in case some events are added
            // Or modified during the execution of an event.
            var hooksCopy = new SignalPriorityWrapper[hookList.Count];
            hookList.CopyTo(hooksCopy, 0);
            foreach(SignalPriorityWrapper signal in hooksCopy)
            {
                result = signal?.Signal(result);
            }
            return result;
        }
    }
}
