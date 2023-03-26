using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace World.InteractiveObjects.Activables
{
    public class Wire : BaseActivable
    {
        [SerializeField]
        private WireScriptableObject wireSO;
        private Tilemap tilemap;

        protected override void OnActivate()
        {
            foreach(var tilePair in wireSO.tilePairs)
            {
                tilemap.SwapTile(tilePair.original,tilePair.active);
            }
        }

        protected override void OnDeactivate()
        {
            foreach (var tilePair in wireSO.tilePairs)
            {
                tilemap.SwapTile(tilePair.active, tilePair.original);
            }
        }

        private void Awake()
        {
            tilemap = GetComponent<Tilemap>();
        }
    }
}
