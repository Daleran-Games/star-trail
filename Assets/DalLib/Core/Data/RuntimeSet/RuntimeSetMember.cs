using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public abstract class RuntimeSetMember<T> : MonoBehaviour
    {
        public RuntimeSet<T> set;
        public T obj;

        void OnEnable()
        {
            set.Add(obj);
        }

        void OnDisable()
        {
            set.Remove(obj);
        }
        
    }
}

