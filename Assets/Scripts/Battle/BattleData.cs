using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleData {
    public static List<GameObject> playerTeam = new List<GameObject>();
    public static List<GameObject> enemyTeam = new List<GameObject>();

    private static bool CheckIfTeamWins(List<GameObject> team) {
        if (team.Count > 0) {
            for (int i = 0; i < team.Count; i++) {
                if (!team[i].GetComponent<CharacterUnitController>().isDead) return false;
            }
            return true;
        }
        return false;
    }
    
    public static bool CheckIfPlayerWins() {
        return CheckIfTeamWins(enemyTeam);
    }

    public static bool CheckIfEnemyWins() {
        return CheckIfTeamWins(playerTeam);
    }
}
