using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData {
    public int posX;
    public int posY;
    public int tileType;

    

    public TileData(int posX, int posY) {
        this.posX = posX;
        this.posY = posY;
    }

}
