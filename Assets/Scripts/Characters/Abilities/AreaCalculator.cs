using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AreaCalculator : MonoBehaviour
{
    public abstract List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam);

    public GameObject getTarget(int x, int y, bool isPlayerTeam) {
        List<GameObject> team = getTeam(isPlayerTeam);
        GameObject target = null;
        for (int i = 0; i < team.Count && target == null; i++) {
            Unit unit = team[i].GetComponent<Unit>();
            if (unit.tileX == x && unit.tileY == y) target = team[i];
        }
        return target;
    } 

    public bool isTargetInTile(int x, int y, bool isPlayerTeam) {
        List<GameObject> targets = getTeam(isPlayerTeam);
        for (int i = 0; i < targets.Count; i++) {
            Unit unit = targets[i].GetComponent<Unit>();
            if (unit.tileX == x && unit.tileY == y) return true;
        }
        return false;
    }

    public List<GameObject> getTeam(bool isPlayerTeam) {
        if (isPlayerTeam) return BattleData.playerTeam;
        else return BattleData.enemyTeam;
    }
}
