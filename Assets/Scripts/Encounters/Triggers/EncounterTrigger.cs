using System.Collections;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public abstract class EncounterTrigger : MonoBehaviour
    {
        [SerializeField]
        protected Encounter _encounter;

        [SerializeField]
        protected bool _repeatable = false;
        protected int _visited = 0;

        protected bool CanVisit()
        {
            if ((_repeatable == true || _visited < 1) && _encounter != null)
            {
                return true;
            }
            return false;
        }

        protected void Visit()
        {
            _visited++;
        }
    }
}