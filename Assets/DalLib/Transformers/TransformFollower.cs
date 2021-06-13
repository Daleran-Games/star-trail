using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class TransformFollower : MonoBehaviour
    {
        public Transform Target;
        public Vector3 Offset = new Vector3(0f, 0f, -10f);
        public bool UseLateUpdate = false;

        void Update()
        {
            if (!UseLateUpdate)
                Move();
        }

        void LateUpdate()
        {
            if (UseLateUpdate)
                Move();
        }

        // Update is called once per frame
        void Move()
        {
            if (Target != null)
                transform.position = Target.transform.position + Offset;
        }
    }
}

