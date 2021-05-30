using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AreaCalculator : ScriptableObject {

    public List<GameObject> targets = new List<GameObject>();

    public abstract List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam, string cardinalPosition);

    protected void resetTargets() {
        targets = new List<GameObject>();
    }

    protected GameObject getTarget(int x, int y, bool isPlayerTeam) {
        List<GameObject> team = getTeam(isPlayerTeam);
        GameObject target = null;
        for (int i = 0; i < team.Count && target == null; i++) {
            Unit unit = team[i].GetComponent<Unit>();
            if (unit.tileX == x && unit.tileY == y) target = team[i];
        }
        return target;
    }

    protected bool isTargetInTile(int x, int y, bool isPlayerTeam) {
        List<GameObject> targets = getTeam(isPlayerTeam);
        for (int i = 0; i < targets.Count; i++) {
            Unit unit = targets[i].GetComponent<Unit>();
            CharacterUnitController ch = targets[i].GetComponent<CharacterUnitController>();
            if (unit.tileX == x && unit.tileY == y && !ch.isDead) return true;
        }
        return false;
    }

    protected void addTarget(int initX, int initY, bool isPlayerTeam) {
        if (isTargetInTile(initX, initY, isPlayerTeam)) { targets.Add(getTarget(initX, initY, isPlayerTeam)); }
    }

    protected List<GameObject> getTeam(bool isPlayerTeam) {
        if (isPlayerTeam) return BattleData.playerTeam;
        else return BattleData.enemyTeam;
    }

    public string getCardinalPosition(int tileX, int tileY, int actorX, int actorY) {
        string cardinalPoint = "";
        if (tileX > actorX) cardinalPoint = "N";
        else cardinalPoint = "S";
        if (tileY > actorY) cardinalPoint = "E";
        else cardinalPoint = "W";

        return cardinalPoint;
    }
}
