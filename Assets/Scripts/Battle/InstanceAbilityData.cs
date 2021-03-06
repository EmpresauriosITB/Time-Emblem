using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InstanceAbilityData {

    public static Abilities ability = null;
    public static TileMap map;
    public static List<ClickableTile> tiles = new List<ClickableTile>();
    private static bool actorIsPlayer;

    public static void instanceAbility(Abilities a, TileMap m, ClickableTile tile) {
        tiles.Add(tile);
        ability = a;
        map = m;
    }

    public static void doAbility(int x, int y, bool targetIsPlayer, GameObject actor) {
        if (ability != null) {
            if (actor == null) { actor = map.selectedUnit; }
            actorIsPlayer = actor.GetComponent<CharacterUnitController>().isPlayer;
            Unit u = actor.GetComponent<Unit>();
            string cardinalPosition = ability.areaCalculator.getCardinalPosition(x, y, u.tileX, u.tileY);
            if (ability.TargetAllies) { targetIsPlayer = !targetIsPlayer; }
            bool abilityDone = ability.abilityBehaviour.doAbility(ability.Power, ability.isPhysical, ability.areaCalculator.calculateArea(x, y, ability.Area, targetIsPlayer, cardinalPosition), actor, ability.isRangeAttack);
            deleteInstance();
            if (abilityDone) { actor.GetComponent<CharacterUnitController>().actionsLeft--; }
        }
    }

    private static void deleteInstance() {
        if (actorIsPlayer)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i] != null)
                {
                    tiles[i].currentState = TileState.nothing;
                    tiles[i].gameObject.GetComponent<MeshRenderer>();
                }
            }
        }
        
        ability = null;
        map = null;
        tiles = new List<ClickableTile>();
    }
}
