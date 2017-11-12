using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HardWorld
{
    public sealed class Chunk : MonoBehaviour
    {
    }

    public class TestBug : MonoBehaviour
    {
        readonly Dictionary<Vector3Int, Tuple<GameObject, Chunk>> _chunks = new Dictionary<Vector3Int, Tuple<GameObject, Chunk>>();

        private void Start()
        {
            for (byte x = 0; x < 24; x++)
            for (byte y = 0; y < 24; y++)
            for (byte z = 0; z < 24; z++)
            {
                var go = new GameObject();
                go.transform.parent = transform;
                _chunks.Add(new Vector3Int(x, y, z), Tuple.Create(go, go.AddComponent<Chunk>()));
            }
        }
    }
}