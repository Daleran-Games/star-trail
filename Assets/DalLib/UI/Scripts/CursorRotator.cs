using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.UI
{
    public class CursorRotator : MonoBehaviour
    {
        [Header("Input")]
        public Vector3 Point = Vector3.zero;
        public Transform TrackedObject;

        float offset;
        RectTransform rect;
        
        // Use this for initialization
        void Start()
        {
            rect = gameObject.GetRequiredComponent<RectTransform>();
            offset = transform.localPosition.magnitude;
        }

        // Update is called once per frame
        void Update()
        {
            if (Point.normalized != Vector3.zero)
            {
                Move();
                Rotate();
            }
        }

        void Move()
        {
            rect.position = TrackedObject.position + Point.normalized * offset;
        }

        void Rotate()
        {
            float angle = Vector2.SignedAngle(transform.up, Point);
            rect.Rotate(0f, 0f, angle);
        }
    }
}

