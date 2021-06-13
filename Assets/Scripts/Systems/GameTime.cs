using UnityEditor;
using UnityEngine;

namespace DaleranGames.StarTrail
{
    public class GameTime : Singleton<GameTime>
    {
        private GameObject _player;
        private Player _playerNav;

        [SerializeField]
        private float _secondsPerDay = 60f;

        [SerializeField]
        [ReadOnly]
        private float _totalTime = 0f;
        public static float TotalTime
        {
            get { return Instance._totalTime; }
        }

        [SerializeField]
        [ReadOnly]
        private int _day = 0;
        public static int Day
        {
            get { return Instance._day; }
        }

        [SerializeField]
        [ReadOnly]
        private float _daySeconds = 0f;

        private void Awake()
        {
            _player = GameObject.Find("Player");
            _playerNav = _player.GetRequiredComponent<Player>();

        }

        private void Update()
        {
            if (_playerNav.CurrentStatus == Player.Status.Moving)
            {
                _daySeconds += Time.deltaTime;
                _totalTime += Time.deltaTime;
            }

            if (_daySeconds > _secondsPerDay)
            {
                StartNewDay();
            }
        }

        private void StartNewDay()
        {
            _daySeconds = 0f;
            _day++;
            Signals.Raise(new SignalData<int>("StartOfDay", Day));
        }
    }
}