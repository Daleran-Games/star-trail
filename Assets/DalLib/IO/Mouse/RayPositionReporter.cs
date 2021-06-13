using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.IO
{
    public class RayPositionReporter : MonoBehaviour
    {
        [Header("Orthographic Camera Settings")]
        [SerializeField]
        float zPlane = 0f;

        [Header("Prespective Camera Settings")]
        [SerializeField]
        Vector3 cursorPlanePoint = Vector3.zero;
        [SerializeField]
        Vector3 cursorPlaneNormal = Vector3.back;
        Plane cursorPlane; // plane on which the cursor move on in 3D space.
        Vector3 lastWorldPosition = Vector3.zero; // last successful raycasted world position for persepctive cameras

        [SerializeField]
        Vector3 worldPosition;
        public Vector3 WorldPosition { get { return worldPosition; } }


        bool isOrthographic = true;
        // Use this for initialization
        void Start()
        {
            if (Camera.main.orthographic)
            {
                isOrthographic = true;
            }
            else
            {
                isOrthographic = false;
                cursorPlane = new Plane(cursorPlaneNormal, cursorPlanePoint);
            }
        }

        // Update is called once per frame
        void Update()
        {
            worldPosition = CalculateWorldPosition(transform.position);
        }

        public Vector3 CalculateWorldPosition(Vector3 mousePosition)
        {
            if (isOrthographic)
            {
                Vector3 pos = MainCamera.Instance.ScreenToWorldPoint(mousePosition);
                return new Vector3(pos.x, pos.y, zPlane);
            }
            else
            {
                Ray ray = MainCamera.Instance.ScreenPointToRay(mousePosition);
                float distance = 0;

                if (cursorPlane.Raycast(ray, out distance))
                    lastWorldPosition = ray.GetPoint(distance);

                return lastWorldPosition;
            }
        }

    }
}

