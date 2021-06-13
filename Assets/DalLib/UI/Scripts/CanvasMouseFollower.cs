using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.UI
{
    public class CanvasMouseFollower : MonoBehaviour
    {
        RectTransform rect;

        void Start()
        {
            rect = GetComponent<RectTransform>();
        }

        void Update()
        {
            rect.anchoredPosition = Input.mousePosition;
        }
    }

}

