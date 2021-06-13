using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Cameras
{
    [AddComponentMenu("Rendering/Step Camera Zoom")]
    public class StepZoom : MonoBehaviour
    {
        [SerializeField]
        float zoomStep = 16f;
        [SerializeField]
        float min = 4f;
        [SerializeField]
        float max = 128f;
        [SerializeField]
        float startZoom = 20f;

        private Vector3 offset;
        private Camera cam;

        void Start()
        {
            offset = new Vector3(0f, 0f, -10f);
            cam = gameObject.GetRequiredComponent<Camera>();
            cam.orthographicSize = startZoom;

        }

        void LateUpdate()
        {
            if (Input.mouseScrollDelta.y / 10 > 0)
                ZoomCameraIn();
            else if (Input.mouseScrollDelta.y / 10 < 0)
                ZoomCameraOut();
        }

        void ZoomCameraIn()
        {
            cam.orthographicSize -= zoomStep;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max);
        }

        void ZoomCameraOut()
        {
            cam.orthographicSize += zoomStep;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max);
        }
    }
}
