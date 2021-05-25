using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AreaCalculator : MonoBehaviour {

    public List<GameObject> targets = new List<GameObject>();

    public abstract List<GameObject> calculateArea(int initX, int initY, int range, bool isPlayerTeam, string cardinalPosition);

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

    public void addTarget(int initX, int initY, bool isPlayerTeam) {
        if (isTargetInTile(initX, initY, isPlayerTeam)) { targets.Add(getTarget(initX, initY, isPlayerTeam)); }
    }

    public List<GameObject> getTeam(bool isPlayerTeam) {
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
