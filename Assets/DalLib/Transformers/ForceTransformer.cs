using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class ForceTransformer : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5;

        [SerializeField]
        [ReadOnly]
        private Vector2 movement;

        private Rigidbody2D playerRigidbody;

        // Use this for initialization
        void Start()
        {
            playerRigidbody = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Move(horizontalMovement, verticalMovement);

        }

        void Move(float h, float v)
        {
            movement.Set(h, v);
            movement = movement.normalized * speed;
            playerRigidbody.AddForce(movement);
        }
    }
}