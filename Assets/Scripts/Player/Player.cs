using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        [ReadOnly]
        private Place _currentLocation;

        [SerializeField]
        [ReadOnly]
        private Location _destination;

        private float _arrivalTolerance = 0.1f;

        private Stat _speedStat;

        public enum Status
        {
            Hold,
            Moving,
            Ready
        }

        [SerializeField]
        private Status _currentStatus;
        public Status CurrentStatus
        {
            get { return _currentStatus; }
            set { _currentStatus = value;  }
        }

        private Rigidbody2D _rb;

        private List<Place> _travelLog;

        public class PlayerArriveLocationSignal : ISignalData
        {
            public string SignalName { get { return "PlayerArriveLocation"; } }
            public Location Location { get; private set; }
            public Player Nav { get; private set; }

            public PlayerArriveLocationSignal(Location location, Player nav)
            {
                Location = location;
                Nav = nav;
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            _travelLog = new List<Place>();
            _rb = gameObject.GetRequiredComponent<Rigidbody2D>();
            var start = GameObject.FindWithTag("StartingNode");
            _rb.position = start.transform.position;
            _currentStatus = Status.Ready;
            _currentLocation = start.gameObject.GetRequiredComponent<Place>();
            _travelLog.Add(_currentLocation);
            Signals.Raise(new PlayerArriveLocationSignal((Location)_currentLocation, this));
            var speedStatSigData = (SignalData<Stat>)Signals.Raise(new SignalData<Stat>("StatSpeedGet", null));
            _speedStat = speedStatSigData.Data;
            Debug.Log(_speedStat.CurrentValue + " / " + _speedStat.Id);
        }

        private void OnEnable()
        {
            Signals.Listen("LocationClick", OnLocationClick);
            Signals.Listen(Stock.AtMinSignal("Fuel"), OnOutOfFuel);
            Signals.Listen("NavStatusChange", OnNavStatusChange);
        }

        // Update is called once per frame
        private void Update()
        {
            Move();
            CheckIfAtDestination();
        }

        public ISignalData OnLocationClick(ISignalData data)
        {
            var locationSig = (Location.LocationClickSignal)data;
            if (locationSig != null)
            {
                SetDestination(locationSig.Location);
            }
            return data;
        }

        public bool CanMove(Location location)
        {
            if (_currentStatus == Status.Ready
                && _currentLocation.IsConnected(location)
                && location != _currentLocation)
            {
                return true;
            }
            return false;
        }

        public bool SetDestination(Location destination)
        {
            if (!CanMove(destination))
            {
                return false;
            }
            _destination = destination;
            _currentStatus = Status.Moving;
            _currentLocation = _currentLocation.FindLaneTo(destination);
            _travelLog.Add(_currentLocation);
            return true;
        }

        public void Move()
        {
            if (_currentStatus == Status.Moving && _destination != null)
            {
                var step = _speedStat.CurrentValue * Time.deltaTime;
                var movement = (_destination.transform.position - transform.position).normalized * step;
                transform.position += movement;
            }
        }


        public void CheckIfAtDestination()
        {
            if (_currentStatus != Status.Moving)
            {
                return;
            }

            float distance = Vector3.Distance(_destination.transform.position, transform.position);

            if (distance > _arrivalTolerance)
            {
                return;
            }

            _currentStatus = Status.Ready;
            _currentLocation = _destination;
            _travelLog.Add(_currentLocation);
            Signals.Raise(new PlayerArriveLocationSignal(_destination, this));
            _destination = null;
            transform.position = _currentLocation.transform.position;
        }

        private ISignalData OnOutOfFuel(ISignalData data)
        {
            // _currentStatus = Status.Hold;
            return data;
        }

        private ISignalData OnNavStatusChange(ISignalData data)
        {
            var status = (SignalData<Status>)data;
            _currentStatus = status.Data;
            return data;
        }
    }

}