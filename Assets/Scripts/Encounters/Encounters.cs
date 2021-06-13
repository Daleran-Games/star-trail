using UnityEngine;
using UnityEngine.UI;

namespace DaleranGames.StarTrail
{
    public class Encounters : Singleton<Encounters>
    {

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private Text _title;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private ChoiceButtons _choices;

        private void OnEnable()
        {
            Signals.Listen("EncounterStart", OnEncounterStart);
            Signals.Listen("EncounterEnd", OnEncounterEnd);
        }

        private void Start()
        {
            _canvas.gameObject.SetActive(false);
        }

        public ISignalData OnEncounterStart(ISignalData data)
        {
            Signals.Raise(new SignalData<Player.Status>("NavStatusChange", Player.Status.Hold));
            _canvas.gameObject.SetActive(true);
            var encounterSignal = (SignalData<Encounter>)data;
            var encounter = encounterSignal.Data;
            _title.text = encounter.Title;
            _description.text = encounter.Description;
            CreateButtons(encounter);
            return data;
        }

        public ISignalData OnEncounterEnd(ISignalData data)
        {
            _canvas.gameObject.SetActive(false);
            Signals.Raise(new SignalData<Player.Status>("NavStatusChange", Player.Status.Ready));
            return data;
        }

        private void CreateButtons(Encounter encounter)
        {
            _choices.ResetAll();
            for(int i = 0; i < encounter.Choices.Length; i++)
            {
                _choices.SetupButton(i, encounter.Choices[i].Text, encounter.Choices[i].OnSelectedEvent);
            }
        }
    }
}