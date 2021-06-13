using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.Transformers
{
    public class MouseGridFollower : MonoBehaviour
    {
        [SerializeField]
        GridLayout grid;
        [SerializeField]
        RayPositionReporter cursor;
        [SerializeField]
        [ReadOnly]
        Vector3Int gridPosition;
        public Vector3Int GridPosition { get { return gridPosition; } }
        Vector3Int lastPosition;
        public event System.Action<Vector3Int> Moved;

        private void Start()
        {
            lastPosition = grid.WorldToCell(cursor.WorldPosition);
        }

        // Update is called once per frame
        void Update()
        {
            gridPosition = grid.WorldToCell(cursor.WorldPosition);

            if (gridPosition != lastPosition)
            {
                Moved?.Invoke(gridPosition);
                lastPosition = gridPosition;
            }


            transform.position = gridPosition;
        }
    }
}