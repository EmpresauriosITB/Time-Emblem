using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CubeArea")]
public class CubeArea : AreaCalculator {
    private TileMap map;

    public override List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam, string cardinalPosition) {
        resetTargets();

        map = GameObject.Find("Map").GetComponent<TileMap>();
        discoverTargetsInArea(range, initX, initY, isPlayerTeam);

        return targets;
    }

    public void discoverTargetsInArea(float movementsLeft, int x, int y, bool isPlayerTeam) {
        if (movementsLeft > 0) {
            for (int i = 0; i < map.abilityGraph[x, y].neighbours.Count; i++) {
                int currentX = map.abilityGraph[x, y].neighbours[i].x;
                int currentY = map.abilityGraph[x, y].neighbours[i].y;
                addTarget(currentX, currentY, isPlayerTeam);

                discoverTargetsInArea(movementsLeft - 1, currentX, currentY, isPlayerTeam);
            }
        }
    }
}
