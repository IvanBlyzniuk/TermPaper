using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "WireMap", menuName = "Scriptable Objects/Wires/WireMap", order = 1)]
public class WireScriptableObject : ScriptableObject
{
    [System.Serializable]
    public class TilePairEntry
    {
        public Tile original;
        public Tile active;
    }
    public List<TilePairEntry> tilePairs;
}
