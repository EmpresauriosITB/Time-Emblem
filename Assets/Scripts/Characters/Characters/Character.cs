using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject {

    public Stats stats; 

    public string characterName; 

    public int currentHp; 
    public int currentPhysicalPower; 
    public int currentPhysicalDefense; 
    public int currentMentalPower; 
    public int currentMentalDefense; 
    public int currentVelocity; 
    public int currentGridSpeed; 

    public AbilitySet abilitieSet; 
    public Abilities specialPassive; 
    public void InitCurrentStats() {
        currentHp = (int) stats.hp;
        currentPhysicalPower = (int) stats.physicalPower;
        currentPhysicalDefense = (int) stats.physicalDefense;
        currentMentalPower = (int) stats.mentalPower;
        currentMentalDefense = (int) stats.mentalDefense;
        currentVelocity = (int) stats.velocity;
        currentGridSpeed = (int) stats.gridSpeed;
    }
}
