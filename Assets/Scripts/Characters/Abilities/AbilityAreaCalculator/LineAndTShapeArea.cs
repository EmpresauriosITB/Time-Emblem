using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAndTShapeArea : AreaCalculator {

    public bool isTShape;

    public override List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam, string cardinalPosition) { 
        
        for (int i = 0; i < range; i++) {
            calculateAreaByCardinalPosition(initX, initY, isPlayerTeam, cardinalPosition, i, range);
        }

        return targets;
    }

    private void calculateAreaByCardinalPosition(int x, int y, bool isPlayerTeam, string cardinalPosition, int num, int range) {
        switch (cardinalPosition) {
            case "N":
                x += num;
                break;
            case "S":
                x -= num;
                break;
            case "E":
                y += num;
                break;
            case "W":
                y -= num;
                break;
        }
        addTarget(x, y, isPlayerTeam);
        if (isTShape && num == range - 1) {
            calculateLastTShapeTiles(x, y, isPlayerTeam, cardinalPosition);
        }
    }

    private void calculateLastTShapeTiles(int x, int y, bool isPlayerTeam, string cardinalPosition) {
        switch (cardinalPosition) {
            case "N":
            case "S":
                addTarget(x + 1, y, isPlayerTeam);
                addTarget(x - 1, y, isPlayerTeam);
                break;
            case "E":
            case "W":
                addTarget(x, y + 1, isPlayerTeam);
                addTarget(x, y - 1, isPlayerTeam);
                break;
        }
    }
}
