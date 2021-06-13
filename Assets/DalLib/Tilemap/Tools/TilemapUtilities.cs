using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Tilemaps
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Tilemap))]
    public class TilemapUtilities : MonoBehaviour
    {
        [SerializeField]
        Tilemap tilemap;

        private void OnValidate()
        {
            tilemap = GetComponent<Tilemap>();
        }

        [ContextMenu("Clear Tilemap")]
        public void ClearTilemap()
        {
            tilemap.ClearAllTiles();
        }


    }
}

