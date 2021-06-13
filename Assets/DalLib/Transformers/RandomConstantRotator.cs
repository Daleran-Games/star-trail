using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class RandomConstantRotator : MonoBehaviour
    {
        [SerializeField]
        Vector2 RandomRotationSpeed;
        float speed;


        // Use this for initialization
        void Start()
        {
            speed = Random.Float(RandomRotationSpeed.x, RandomRotationSpeed.y);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
        }
    }
}

