using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ConeArea")]
public class ConeArea : AreaCalculator {

    public override List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam, string cardinalPosition) {
        resetTargets();

        for (int i = 0; i < range; i++) {
            calculateAreaByCardinalPosition(initX, initY, isPlayerTeam, cardinalPosition, i, range);
        }

        return null;
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
        for (int i = 0; i < num; i++) {
            calculateAreaByCone(x, y, isPlayerTeam, cardinalPosition, i);
        }
    }

    private void calculateAreaByCone(int x, int y, bool isPlayerTeam, string cardinalPosition, int num) {
        switch (cardinalPosition) {
            case "N":
            case "S":
                addTarget(x + num, y, isPlayerTeam);
                addTarget(x - num, y, isPlayerTeam);
                break;
            case "E":
            case "W":
                addTarget(x, y + num, isPlayerTeam);
                addTarget(x, y - num, isPlayerTeam);
                break;
        }
    }
}
