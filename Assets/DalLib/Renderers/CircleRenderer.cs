using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Renderers
{
    [RequireComponent(typeof(LineRenderer))]
    [ExecuteInEditMode]
    public class CircleRenderer : MonoBehaviour
    {
        [SerializeField]
        private int segments = 50;
        public int Segments
        {
            get { return segments; }
            set
            {
                segments = value;
                Render(); 
            }
        }

        [SerializeField]
        private float xRadius = 1f;
        public float XRadius
        {
            get { return xRadius; }
            set
            {
                xRadius = value;
                Render();
            }
        }

        [SerializeField]
        private float yRadius = 1f;
        public float YRadius
        {
            get { return yRadius; }
            set
            {
                yRadius = value;
                Render();
            }
        }

        private LineRenderer lineRenderer;

        private void OnValidate()
        {
            Render();
        }

        // Use this for initialization
        void Start()
        {
            Render();
        }

        private void Render()
        {
            if (lineRenderer == null)
                lineRenderer = GetComponent<LineRenderer>();

            lineRenderer.positionCount = segments + 1;
            lineRenderer.useWorldSpace = false;

            float x, y;       
            float angle = 0f;

            for (int i = 0; i < (segments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * XRadius;
                y = Mathf.Cos(Mathf.Deg2Rad * angle) * YRadius;

                lineRenderer.SetPosition(i, new Vector3(x, y, 0f));
                angle += (360f / segments);
            }
        }
    }
}