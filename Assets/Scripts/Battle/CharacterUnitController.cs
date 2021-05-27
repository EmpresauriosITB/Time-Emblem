using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnitController : MonoBehaviour {

    public Character character;
    public Unit unit;
    public int actionsLeft;
    [SerializeField]
    private float timeToNextActivePeriod;
    public bool isPlayer;
    public bool isDead = false;
    public TileMap map;

    public BattleManager bm;

    public delegate void SetCurrentActiveCharacter(GameObject activeChar);
    public event SetCurrentActiveCharacter setCurrentActiveCharacter;


    void Start() {
        character.InitCurrentStats();
        timeToNextActivePeriod = Time.time + character.currentVelocity;
        resetActions();
    }

    void Update() {
        if (actionsLeft <= 0) {
            bm.isDefocused = true;
            timeToNextActivePeriod = Time.time + character.currentVelocity;
            resetActions();
        }
        if (character.currentHp <= 0 && !isDead) {
            isDead = true;
        }
    }

    void OnMouseUp() {
        if (!isDead) {
            if (isPlayer && timeToNextActivePeriod < Time.time) { bm.SetCurrentaActiveCharacter(this.gameObject); }
            else { InstanceAbilityData.doAbility(unit.tileX, unit.tileY, false, null); }
        }
	}

    public bool canCharBeActivated() {
        return timeToNextActivePeriod < Time.deltaTime;
    }

    public void InitBattleManager(BattleManager bm, TileMap map) {
        this.bm = bm;
        this.map = map;
    }

    public void ResetCooldown() {
        timeToNextActivePeriod = Time.deltaTime + character.currentVelocity;
    }

    public bool HasActionsLeft() {
        return actionsLeft > 0;
    }

    public void resetActions() {
        actionsLeft = (int)character.stats.numActions;
    }
}
