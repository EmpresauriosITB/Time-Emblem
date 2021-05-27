using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TileSet")]
public class TileSet : ScriptableObject {

    public int x, y;

    public int playerInitX, playerInitY;
    public TileData[] tileMapData;
    public TileType[] tileTypes;
    public EnemyTeam enemyTeam;



    public void Init() {
        tileMapData = new TileData[x*y];
        int auxX = 0, auxY = 0;
        for (int i = 0; i < tileMapData.Length; i++) {
            tileMapData[i] = new TileData(auxX, auxY);           
            if (auxY < y - 1) { auxY ++; }
            else {
                auxX ++;
                auxY = 0;
            }
        }
    }

    public void changeArrayLenghtX(int x) {
        this.x = x;
    }

    public void changeArrayLenghtY(int y) {
        this.y = y;
    }

    public void ApplyChanges() {
        Init();
    }

    public int GetX() {
        return x;
    }
    public int GetY() {
        return y;
    }
}
