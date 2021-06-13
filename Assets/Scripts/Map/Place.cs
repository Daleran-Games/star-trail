using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class Place : MonoBehaviour
    {
        public virtual bool IsConnected(Location location) { return false; }
        public virtual Lane FindLaneTo(Location location) { return null; }
    }
}
