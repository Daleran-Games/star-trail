using UnityEngine;
using System.Collections;

namespace DaleranGames
{
    public class ToggleGameObject : MonoBehaviour
    {

        public void Toggle(GameObject opject)
        {
            opject.SetActive(!opject.activeSelf);
        }
    }
}

