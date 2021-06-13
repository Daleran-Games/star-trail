using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Cameras
{
    public class ScreenSizeObserver : MonoBehaviour
    {
        Vector2Int screenSize;
        public Vector2Int ScreenSize { get { return screenSize; } }
        public event System.Action<Vector2Int> ScreenSizeChanged;


        // Use this for initialization
        void Start()
        {
            screenSize = new Vector2Int(Screen.width, Screen.height);
        }

        // Update is called once per frame
        void Update()
        {
            if (Screen.width != screenSize.x || Screen.height != screenSize.y)
            {
                screenSize = new Vector2Int(Screen.width, Screen.height);
                ScreenSizeChanged?.Invoke(screenSize);
            }
        }
    }
}


