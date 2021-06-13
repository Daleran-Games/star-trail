using System.Collections;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    [CreateAssetMenu(fileName = "NewEncounter", menuName = "StarTrail/Encounters/Encounter", order = 1)]
    public class Encounter : ScriptableObject
    {
        [SerializeField]
        private string _title;
        public string Title { get { return _title; } }

        [SerializeField]
        [TextArea]
        private string _description;
        public string Description { get { return _description; } }

        [SerializeField]
        private Choice[] _choices;
        public Choice[] Choices { get { return _choices; } }
    }
}