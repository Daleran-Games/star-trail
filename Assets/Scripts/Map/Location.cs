using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{

    public class Location : Place
    {
        [SerializeField]
        [ReadOnly]
        private List<Lane> _lanes = new List<Lane>();

        public class LocationClickSignal : ISignalData
        {
            public string SignalName { get { return "LocationClick"; } }
            public Location Location { get; private set; }

            public LocationClickSignal(Location location)
            {
                Location = location;
            }
        }

        private void Awake()
        {
            Physics2D.queriesHitTriggers = true;
        }

        // Start is called before the first frame update
        private void OnDisable()
        {
            _lanes.Clear();
        }

        private void OnMouseDown()
        {
            Signals.Raise(new LocationClickSignal(this));
        }

        public void AddLane(Lane lane)
        {
            if(!_lanes.Contains(lane))
            {
                _lanes.Add(lane);
            }
        }

        public override bool IsConnected(Location location)
        {
            foreach(Lane lane in _lanes)
            {
                if(lane.IsConnected(location)) {
                    return true;
                }
            }
            return false;
        }

        public override Lane FindLaneTo(Location location)
        {
            foreach (Lane lane in _lanes)
            {
                if (lane.IsConnected(location))
                {
                    return lane;
                }
            }
            return null;
        }
    }

}