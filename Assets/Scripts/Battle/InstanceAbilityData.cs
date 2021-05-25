using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InstanceAbilityData {

    public static Abilities ability = null;
    public static TileMap map;
    public static List<ClickableTile> tiles = new List<ClickableTile>();


    public static void instanceAbility(Abilities a, TileMap m, ClickableTile tile) {
        tiles.Add(tile);
        ability = a;
        map = m;
    }

    public static void doAbility(int x, int y, bool targetIsPlayer, GameObject actor) {
        if (ability != null) {
            if (actor == null) { actor = map.selectedUnit; }
            Unit u = actor.GetComponent<Unit>();
            string cardinalPosition = ability.areaCalculator.getCardinalPosition(x, y, u.tileX, u.tileY);
            bool abilityDone = ability.abilityBehaviour.doAbility(ability.Power, ability.isPhysical, ability.areaCalculator.calculateArea(x, y, ability.Area, targetIsPlayer, cardinalPosition), map.selectedUnit);
            deleteInstance();
            if (abilityDone) {
                actor.GetComponent<CharacterController>().actionsLeft--;
            }
        }
    }

    private static void deleteInstance() {
        for (int i = 0; i < tiles.Count; i++) {
            tiles[i].currentState = TileState.nothing;
            tiles[i].gameObject.GetComponent<MeshRenderer>();
        }
        ability = null;
        map = null;
        tiles = new List<ClickableTile>();
    }

}
