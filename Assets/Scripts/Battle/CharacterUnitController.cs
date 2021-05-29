using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnitController : MonoBehaviour {

    public Character character;
    public Unit unit;
    public int actionsLeft;
    [SerializeField]
    public float timeToNextActivePeriod;
    public bool isPlayer;
    public bool isDead = false;
    public TileMap map;
    public List<BuffAndDebuff> buffAndDebuffs;
    public Animator animator;
    public bool isHumanoid;

    public BattleManager bm;
    public StatesMachine sm;

    public int currentHp;
    public int currentPhysicalPower;
    public int currentPhysicalDefense;
    public int currentMentalPower;
    public int currentMentalDefense;
    public int currentVelocity;
    public int currentGridSpeed;


    public void InitCurrentStats()
    {
        currentHp = (int)character.stats.hp;
        currentPhysicalPower = (int)character.stats.physicalPower;
        currentPhysicalDefense = (int)character.stats.physicalDefense;
        currentMentalPower = (int)character.stats.mentalPower;
        currentMentalDefense = (int)character.stats.mentalDefense;
        currentVelocity = (int)character.stats.velocity;
        currentGridSpeed = (int)character.stats.gridSpeed;
    }


    void Start() {
        InitCurrentStats();
        timeToNextActivePeriod = Time.time + currentVelocity;      
            
        resetActions();
    }

    void Update() {
        if (buffAndDebuffs.Count > 0) {
            for (int i =0; i < buffAndDebuffs.Count; i++) {
                if (buffAndDebuffs[i].checkEffectTime()) buffAndDebuffs.Remove(buffAndDebuffs[i]);
            }
        }
        if (actionsLeft <= 0) {
            bm.isDefocused = true;
            timeToNextActivePeriod = Time.time + currentVelocity;
            resetActions();
            if (!isPlayer)
            {
                sm.state = StatesMachine.State.NotActive;
            }
            
        }
        if (currentHp <= 0 && !isDead) {
            if (isHumanoid) { animator.SetTrigger("DeathTrigger"); }
            else { animator.SetTrigger("death"); }
            isDead = true;
        }
    }

    void OnMouseUp() {

        if (!isDead) {
            if (isPlayer && checkTime() && bm.activeChar == null) { bm.SetCurrentaActiveCharacter(this.gameObject); }
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
        timeToNextActivePeriod = Time.deltaTime + currentVelocity;
    }

    public bool HasActionsLeft() {

        return actionsLeft > 0;
    }

    public void resetActions() {
        actionsLeft = (int)character.stats.numActions;
    }

    public bool checkTime()
    {
        return timeToNextActivePeriod < Time.time;
    }
}
