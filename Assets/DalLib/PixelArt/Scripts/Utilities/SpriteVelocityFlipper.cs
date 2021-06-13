using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.PixelArt
{
    public class SpriteVelocityFlipper : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer sprite;

        [SerializeField]
        Rigidbody2D rb2D;


        // Use this for initialization
        void Start()
        {
            if (sprite == null)
                sprite = GetComponent<SpriteRenderer>();

            if (rb2D== null)
                rb2D = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            if (sprite.flipX == false && rb2D.velocity.x < 0)
                sprite.flipX = true;
            else if (sprite.flipX == true && rb2D.velocity.x > 0)
                sprite.flipX = false;
        }
    }
}