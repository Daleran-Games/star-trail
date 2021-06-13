using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DaleranGames
{
    public class Pause : MonoBehaviour
    {

        Canvas canvas;

        void Start()
        {
            canvas = GetComponent<Canvas>();
            canvas.enabled = false;
        }

        public void PauseApplication()
        {
            canvas.enabled = !canvas.enabled;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }

    }
}