using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    public static void setAllowedToCLickTiles(float movementsLeft, int x, int y, bool activate, TileMap tileMap) {
        if (movementsLeft > 0) {
            for (int i = 0; i < tileMap.graph[x,y].neighbours.Count; i++) {
                int currentX = tileMap.graph[x,y].neighbours[i].x;
                int currentY = tileMap.graph[x,y].neighbours[i].y;
                if (tileMap.isWalkable(currentX,currentY)) {
                    tileMap.ActivateTile(currentX, currentY, activate);
                    setAllowedToCLickTiles(movementsLeft - tileMap.tileSet.tileTypes[tileMap.currentTiles[currentX,currentY]].movementCost, currentX, currentY, activate, tileMap);
                }
            }
        }
    } 
}
