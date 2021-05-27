using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTarget : AreaCalculator {
    public override List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam, string cardinalPosition) {
        addTarget(initX, initY, isPlayerTeam);

        return targets;
    }
}
