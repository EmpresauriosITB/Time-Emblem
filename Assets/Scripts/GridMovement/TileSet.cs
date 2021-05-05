using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TileSet")]
public class TileSet : ScriptableObject {
    public TileData[] tileMapData;
    public TileType[] tileTypes;
}
