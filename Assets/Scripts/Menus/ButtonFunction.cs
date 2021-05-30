using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    private TextLogController tlg;
    private Abilities abilities;
    private GameObject character;

 
    public void subscribeEvent(TextLogController evento, Abilities a, GameObject character)
    {
        this.character = character;
        abilities = a;
        tlg = evento;
        evento.destroyText += DestroyText;
    }

    public void DestroyText()
    {
        tlg.destroyText -= DestroyText;
        Destroy(this.gameObject);
    }

    public void buttonClicked() {
        Unit unit = character.GetComponent<Unit>();
        CharacterUnitController currentChar = character.GetComponent<CharacterUnitController>();
        if (abilities.needsArea)
        {
            PathFind.setAllowedToCLickTiles(currentChar.currentGridSpeed, unit.tileX, unit.tileY, false, unit.map, TileState.nothing, null);
            PathFind.setAllowedToCLickTiles(abilities.Range, unit.tileX, unit.tileY, true, unit.map, TileState.doingAbility, abilities);
        } else {
            List<GameObject> go = new List<GameObject>();
            go.Add(character);
            InstanceAbilityData.instanceAbility(abilities, unit.map, null);
            abilities.abilityBehaviour.doAbility(abilities.Power, abilities.isPhysical, go, character, abilities.isRangeAttack);
            currentChar.actionsLeft--;
        }

    }
}
