using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    [ExecuteInEditMode]
    public class Lane : Place
    {
        [SerializeField]
        private Location _start;
        public Location Start { get { return _start;  } }

        [SerializeField]
        private Location _end;
        public Location End { get { return _end; } }

        private LineRenderer _line;
        private bool _validInput = true;

        // Start is called before the first frame update
        void Awake()
        {
            _line = gameObject.GetRequiredComponent<LineRenderer>();

            if (_start == null || _end == null || _line == null)
            {
                Debug.LogError(gameObject.name + " lane has invalid input.");
                _validInput = false;
            } else
            {
                DrawLines();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying && _validInput)
            {
                DrawLines();
            }
        }

        public override bool IsConnected(Location location)
        {
            if(location == Start || location == End)
            {
                return true;
            }
            return false;
        }

        private void DrawLines()
        {
            var center = _start.transform.position + 0.5f * (_end.transform.position - _start.transform.position);
            transform.position = center;
            _line.positionCount = 2;
            _line.SetPositions(GetPoints());
            _start.AddLane(this);
            _start.gameObject.name = GetLocationName(_start);
            _end.AddLane(this);
            _end.gameObject.name = GetLocationName(_end);
            gameObject.name = GetLaneName();
        }

        private Vector3[] GetPoints()
        {          
            var points = new Vector3[2];
            points[0] = Vector3.MoveTowards(_start.transform.position, _end.transform.position, 1f);
            points[1] = Vector3.MoveTowards(_end.transform.position, _start.transform.position, 1f);
            return points;
        }

        private string GetLocationName(Location location)
        {
            return "Loc(" 
                + location.transform.position.x 
                + "," 
                + location.transform.position.y
                + ")";
        }

        private string GetLaneName()
        {
            return "Lane(" 
                + _start.transform.position.x 
                + "," 
                + _start.transform.position.y
                + ")->("
                + _end.transform.position.x
                + ","
                + _end.transform.position.y 
                + ")";
        }
    }

}