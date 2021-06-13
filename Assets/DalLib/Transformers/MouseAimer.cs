using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class MouseAimer : MonoBehaviour
    {

        [SerializeField]
        [ReadOnly]
        Vector2 aimPoint;
        [SerializeField]
        [ReadOnly]
        Vector2 playerToMouse;
        [SerializeField]
        [ReadOnly]
        float aimAngle;

        private Rigidbody2D playerRigidbody;

        // Use this for initialization
        void Start()
        {
            playerRigidbody = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            TurnPlayer();
        }

        void TurnPlayer()
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            aimPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            playerToMouse = aimPoint - playerRigidbody.position;
            aimAngle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg;

            // Set the player's rotation to this new rotation.
            playerRigidbody.rotation = aimAngle - 90f;

        }
    }
}