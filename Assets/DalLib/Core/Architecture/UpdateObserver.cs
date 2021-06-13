using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class UpdateObserver : MonoBehaviour
    {

        public event Action FixedUpdateEvent;
        public event Action UpdateEvent;
        public event Action LateUpdateEvent;


        void FixedUpdate()
        {
            FixedUpdateEvent?.Invoke();
        }

        void Update()
        {
            UpdateEvent?.Invoke();
        }

        void LateUpdate()
        {
            LateUpdateEvent?.Invoke();
        }

    }
}

