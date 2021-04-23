using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public Stats stats;

    public string characterName;

    private int currentHp;
    private int currentPhysicalPower;
    private int currentPhysicalDefense;
    private int currentMentalPower;
    private int currentMentalDefense;
    private int currentVelocity;
    private int currentGridSpeed;

    public AbilitySet abilitieSet;
    private List<Abilities> abilitiesScript = new List<Abilities>();
    public SpecialPassiveSettings specialPassiveSettings;
    private SpecialPassive specialPassiveScript;

    public void DoAbility(int idAbilityInList) {
        abilitiesScript[idAbilityInList].doAbility();
    }

    public void Init() {
        InitAbilities();
        InitSpecialPassive();
        InitCurrentStats();
    }

    public void InitAbilities() {
        foreach (int id in abilitieSet.abilities) {
            abilitiesScript.Add(AbilityCommon.abilitiesReference[id]);
        }
    }

    public void InitSpecialPassive() {
        specialPassiveScript = SpecialPassiveCommon.specialPassiveReference[(int)specialPassiveSettings.specialPassiveId];
    }

    public void InitCurrentStats() {
        currentHp = (int)GetHp();
        currentPhysicalPower = (int)GetPhysicalPower();
        currentPhysicalDefense = (int)GetPhysicalDefense();
        currentMentalPower = (int)GetMentalPower();
        currentMentalDefense = (int)GetMentalDefense();
        currentVelocity = (int)GetVelocity();
        currentGridSpeed = (int)GetGridSpeed();
    }

    public void UpdateAbilityScript(int id) {
        abilitiesScript.Insert(id, AbilityCommon.abilitiesReference[(int) abilitieSet.abilities[id]]);   
    }

    public void UpdatePassiveScript()
    {
        specialPassiveScript = SpecialPassiveCommon.specialPassiveReference[(int)specialPassiveSettings.specialPassiveId];
    }

    public AbilitySet GetAbilitiesSet() { return abilitieSet; }
    public SpecialPassiveSettings GetSpecialPassiveSettings() { return specialPassiveSettings; }
    public string GetName() { return characterName; }
    public float GetHp() { return stats.hp; }
    public float GetPhysicalPower() { return stats.physicalPower; }
    public float GetPhysicalDefense() { return stats.physicalDefense; }
    public float GetMentalPower() { return stats.mentalPower; }
    public float GetMentalDefense() { return stats.mentalDefense; }
    public float GetVelocity() { return stats.velocity; }
    public float GetForceValue() { return stats.forceValue; }
    public float GetGridSpeed() { return stats.gridSpeed; }
    public Stats GetStats() { return stats; }

    public void SetName(string name) { characterName = name; }
    public void SetHp(float hp) { stats.hp= hp; }
    public void SetPhysicalPower(float physicalPower) { stats.physicalPower = physicalPower; }
    public void SetPhysicalDefense(float physicalDefense) { stats.physicalDefense = physicalDefense; }
    public void SetMentalPower(float mentalPower) { stats.mentalPower = mentalPower; }
    public void SetMentalDefense(float mentalDefense) { stats.mentalDefense = mentalDefense; }
    public void SetVelocity(float velocity) { stats.velocity = velocity; }
    public void SetForceValue(float forceValue) { stats.forceValue = forceValue; }
    public void SetGridSpeed(float gridSpeed) { stats.gridSpeed = gridSpeed; }
    public void SetStats(Stats stats) { this.stats = stats; }
    public void SetAbilitiesSet(AbilitySet abilitieSet) { this.abilitieSet = abilitieSet; }
    public void SetSpecialPassiveSettings(SpecialPassiveSettings specialPassiveSettings) { this.specialPassiveSettings = specialPassiveSettings; }

    public int GetCurrentHp() { return currentHp; }
    public int GetCurrentPhysicalPower() { return currentPhysicalPower; }
    public int GetCurrentPhysicalDefense() { return currentPhysicalDefense; }
    public int GetCurrentMentalPower() { return currentMentalPower; }
    public int GetCurrentMentalDefense() { return currentMentalDefense; }
    public int GetCurrentVelocity() { return currentVelocity; }
    public int GetCurrentGridSpeed() { return currentGridSpeed; }

    public void SetCurrentHp(int hp) { this.currentHp = hp; }
    public void SetCurrentPhysicalPower(int physicalPower) { this.currentPhysicalPower = physicalPower; }
    public void SetCurrentPhysicalDefense(int physicalDefense) { this.currentPhysicalDefense = physicalDefense; }
    public void SetCurrentMentalPower(int mentalPower) { this.currentMentalPower = mentalPower; }
    public void SetCurrentMentalDefense(int mentalDefense) { this.currentMentalDefense = mentalDefense; }
    public void SetCurrentVelocity(int velocity) { this.currentVelocity = velocity; }
    public void SetCurrentGridSpeed(int gridSpeed) { this.currentGridSpeed = gridSpeed; }
}
