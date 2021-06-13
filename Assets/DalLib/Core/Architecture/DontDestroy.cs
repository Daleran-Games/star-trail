using UnityEngine;
using System.Collections;

namespace DaleranGames
{
    public class DontDestroy : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

