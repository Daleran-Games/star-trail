using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class VelocityAligner : MonoBehaviour
    {
        [SerializeField]
        float headingTolerance = 0.1f;
        public float HeadingTolerance { get { return headingTolerance; } }

        Rigidbody2D rb;

        // Use this for initialization
        void Start()
        {
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            RotateShipTovelocity();
        }

        void RotateShipTovelocity()
        {
            if (rb.velocity.magnitude > 0.1f)
            {
                float angle = Vector2.SignedAngle(transform.up, rb.velocity);
                rb.MoveRotation(rb.rotation + angle);
            }
        }
    }
}

