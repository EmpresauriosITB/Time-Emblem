using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Abilities : ScriptableObject {
    private string abilityName;
    private int Power;
    private string description;

    public abstract void doAbility();

    public void SetPower(int power) { Power = power; }
    public int GetPower() { return Power; }

    public void SetName(string name) { abilityName = name; }
    public string GetName() { return abilityName; }

    public void SetDescription(string description) { this.description = description; }
    public string GetDescription() { return description; }

}
