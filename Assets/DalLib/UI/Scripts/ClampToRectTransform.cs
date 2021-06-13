using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.UI
{
    public class ClampToRectTransform : MonoBehaviour
    {
        public RectTransform BoundingRect;
        public bool UseLateUpdate = true;
        Vector3[] corners = new Vector3[4];

        private void Start()
        {
            BoundingRect.GetWorldCorners(corners);
        }

        // Update is called once per frame
        void Update()
        {
            if (!UseLateUpdate)
                transform.position = Clamp(transform.position);
        }

        private void LateUpdate()
        {
            if (UseLateUpdate)
                transform.position = Clamp(transform.position);
        }

        Vector3 Clamp(Vector3 position)
        {
            float x = position.x;
            float y = position.y;

            if (x < corners[0].x)
                x = corners[0].x;
            else if (x > corners[2].x)
                x = corners[2].x;

            if (y < corners[0].y)
                y = corners[0].y;
            else if (y > corners[2].y)
                y = corners[2].y;

            return new Vector3(x, y, position.z);
        }
    }
}

