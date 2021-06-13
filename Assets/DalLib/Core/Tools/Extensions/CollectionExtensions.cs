using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames
{
    public static class CollectionExtensions 
    {
        public static int RandomArrayIndex (this System.Array array)
        {
            return Random.Int(0, array.Length);
        }

        public static int RandomArrayIndex(this System.Array array, int dimension)
        {
            return Random.Int(0, array.GetLength(dimension)-1);
        }

        public static T RandomItem<T>(this IList<T> list)
        {
            return list[RandomIndex<T>(list)];
        }

        public static int RandomIndex<T> (this IList<T> list)
        {
            return Random.Int(0, list.Count);
        }

        public static K RandomKey<K,V>(IDictionary<K,V> dict)
        {
            List<K> keys = (List<K>)dict.Keys;
            return keys[RandomIndex<K>(keys)];
        }

        public static V RandomValue<K, V>(IDictionary<K, V> dict)
        {
            List<V> values = (List<V>)dict.Values;
            return values[RandomIndex<V>(values)];
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Int(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


    }
}
