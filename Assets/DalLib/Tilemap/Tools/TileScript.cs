using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEngine
{
    [System.Serializable]
    public abstract class TileScript : ScriptableObject
    {
        public virtual bool StartUp(Vector3Int location, ITilemap tilemap, GameObject obj)
        {
            return false;
        }

        public virtual void RefreshTile(Vector3Int position, ITilemap tilemap)
        {

        }

    }
}

