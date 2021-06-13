using System.Collections;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class LocationEncounterTrigger : EncounterTrigger
    {
        protected Location _location;

        private void Start()
        {
            _location = gameObject.GetRequiredComponent<Location>();
        }

        private void OnEnable()
        {
            Signals.Listen("PlayerArriveLocation", OnLocationArrive);
        }

        public ISignalData OnLocationArrive(ISignalData data)
        {
            var loc = (Player.PlayerArriveLocationSignal)data;
            if (loc.Location == _location && CanVisit())
            {
                Signals.Raise(new SignalData<Encounter>("EncounterStart", _encounter));
                Visit();
            }
            return data;
        }
    }
}