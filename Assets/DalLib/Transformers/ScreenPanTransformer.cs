using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class ScreenPanTransformer : MonoBehaviour
    {
        public float PanSpeed = 15f;
        public float PanBorderThickness = 20f;
        public bool UseLateUpdate = false;
        float offset;

        private void Start()
        {
            offset = transform.position.z;
        }

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
            Vector2 moveDir = new Vector2();

            if (Input.mousePosition.x > Screen.width - PanBorderThickness)
                moveDir.x = PanSpeed;
            if (Input.mousePosition.x < PanBorderThickness)
                moveDir.x = -PanSpeed;
            if (Input.mousePosition.y > Screen.height - PanBorderThickness)
                moveDir.y = PanSpeed;
            if (Input.mousePosition.y < PanBorderThickness)
                moveDir.y = -PanSpeed;

            transform.position += (Vector3)moveDir.normalized * PanSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, offset);
        }
    }

}
