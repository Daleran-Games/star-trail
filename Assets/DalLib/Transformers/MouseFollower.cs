using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class MouseFollower : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}

