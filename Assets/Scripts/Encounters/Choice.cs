using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DaleranGames.StarTrail
{
    [CreateAssetMenu(fileName = "NewChoice", menuName = "StarTrail/Choices/Choice", order = 2)]
    public class Choice : ScriptableObject
    {
        public UnityAction OnSelectedEvent { get; private set; }

        [SerializeField]
        private string _text;
        public string Text { get { return _text; } }

        [SerializeField]
        private Encounter _followOnEncounter;

        protected virtual void OnEnable()
        {
            OnSelectedEvent += OnSelected;
        }

        public virtual void OnSelected ()
        {
            OnSelectedEvent -= OnSelected;
            if (_followOnEncounter != null)
            {
                Signals.Raise(new SignalData<Choice>("EncounterEnd", this));
                Signals.Raise(new SignalData<Encounter>("EncounterStart", _followOnEncounter));
            }
        }
    }
}