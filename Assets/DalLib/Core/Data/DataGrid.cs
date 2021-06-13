using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections.ObjectModel;

namespace DaleranGames
{
    [System.Serializable]
    public class DataGrid<T>
    {
        protected Dictionary<Vector3Int, T> data;
        protected List<KeyValuePair<Vector3Int, T>> list;

        public ReadOnlyCollection<KeyValuePair<Vector3Int, T>> List { get { return list.AsReadOnly(); } }

        public int Count { get { return data.Count; } }

        protected BoundsInt bounds;
        public BoundsInt Bounds { get { return bounds; }}

        public Vector3Int[] Positions { get { return data.Keys.ToArray(); } }
        public T[] Values { get { return data.Values.ToArray(); } }

        public T this[Vector3Int coord]
        {
            get
            {
                T obj;
                if (data.TryGetValue(coord, out obj))
                    return obj;
                else
                    return default(T);
            }

            set
            {
                Add(coord, value, true);
            }
        }

        public DataGrid(BoundsInt bounds)
        {
            data = new Dictionary<Vector3Int, T>();
            list = new List<KeyValuePair<Vector3Int, T>>();
            this.bounds = bounds;
        }

        public bool TryGet(Vector3Int coord, out T obj)
        {
            return data.TryGetValue(coord, out obj);
        }

        public bool ContainsPosition(Vector3Int coord)
        {
            return data.ContainsKey(coord);
        }

        public bool Contains(T item)
        {
            return data.ContainsValue(item);
        }

        public void Add(Vector3Int coord, T item, bool overwrite = true)
        {
            if (ContainsPosition(coord))
            {
                if (overwrite)
                    RemoveAt(coord);
                else
                    return;
            }

            data[coord] = item;
            list.Add(new KeyValuePair<Vector3Int, T>(coord, item));
            //CheckBoundsOnAdd(coord);
        }

        public void Clear()
        {
            data.Clear();
            list.Clear();
            bounds = new BoundsInt();
        }

        public bool RemoveAt(Vector3Int coord)
        {
            if (data.ContainsKey(coord))
            {
                list.Remove(new KeyValuePair<Vector3Int, T>(coord, data[coord]));
                data.Remove(coord);
                //CheckBoundsOnRemove(coord);
                return true;
            }
            else
                return false;
        }

        /*
        void CheckBoundsOnAdd(Vector3Int coord)
        {
            if (!bounds.Contains(coord))
            {
                bounds.SetMinMax(Vector3Int.Min(coord, bounds.min), Vector3Int.Max(coord, bounds.max));
            }
        }

        void CheckBoundsOnRemove(Vector3Int coord)
        {
            if (bounds.Contains(coord))
            {
                bounds.SetMinMax(Vector3Int.Min(coord, bounds.min), Vector3Int.Max(coord, bounds.max));
            }
        }
        */

        public void Merge(DataGrid<T> grid, bool overwrite = true)
        {
            ReadOnlyCollection<KeyValuePair<Vector3Int, T>> oldGrid = grid.List;

            for (int i=0; i<oldGrid.Count; i++)
            {
                Add(oldGrid[i].Key, oldGrid[i].Value, overwrite); 
            }
        }


    }
}