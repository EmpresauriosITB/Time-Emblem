using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTarget : AreaCalculator {
    public override List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam) {
        List<GameObject> targets = new List<GameObject>();
        Debug.Log(isTargetInTile(initX, initY, isPlayerTeam));
        if (isTargetInTile(initX, initY, isPlayerTeam)) { targets.Add(getTarget(initX, initY, isPlayerTeam)); }

        return targets;
    }
}
