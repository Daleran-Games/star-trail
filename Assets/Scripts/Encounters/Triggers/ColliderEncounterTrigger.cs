using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class ColliderEncounterTrigger : EncounterTrigger
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player") && CanVisit())
            {
                Signals.Raise(new SignalData<Encounter>("EncounterStart", _encounter));
                Visit();
            }
        }

    } 
}
