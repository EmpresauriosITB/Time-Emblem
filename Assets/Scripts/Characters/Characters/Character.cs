using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject {

    public Stats stats; 
    public AbilitySet abilitieSet; 
    public Abilities specialPassive; 

    public string characterName; 

    
}
