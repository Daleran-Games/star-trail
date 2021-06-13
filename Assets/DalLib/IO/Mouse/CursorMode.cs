using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaleranGames.IO
{
    [AddComponentMenu("Input/Cursor Mode")]
    public class CursorMode : MonoBehaviour
    {
        public enum MouseRenderer
        {
            None = 0,
            Sprite = 1,
            Hardware = 2
        }

        [SerializeField]
        MouseRenderer renderMode = MouseRenderer.Sprite;

        [SerializeField]
        Image cursorSprite;

        // Use this for initialization
        void Start()
        {
            ChangeMouseRenderingMode(renderMode);
        }

        public void ChangeMouseRenderingMode(MouseRenderer state)
        {
            switch (state)
            {
                case MouseRenderer.None:
                    Cursor.visible = false;
                    cursorSprite.enabled = false;
                    break;
                case MouseRenderer.Sprite:
                    Cursor.visible = false;
                    cursorSprite.enabled = true;
                    break;
                case MouseRenderer.Hardware:
                    Cursor.visible = true;
                    cursorSprite.enabled = false;
                    break;
            }
        }
    }
}

