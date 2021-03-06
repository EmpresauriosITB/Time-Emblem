using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OneTarget")]
public class OneTarget : AreaCalculator {
    public override List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam, string cardinalPosition) {
        resetTargets();
        addTarget(initX, initY, isPlayerTeam);

        return targets;
    }
}
