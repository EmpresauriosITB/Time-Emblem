using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public class Abilities : ScriptableObject {
    public string AbilityName;
    public int Power;
    public string Description;
    public int Range;
    public bool HasAreaEffect;
    public int Area;
    public bool HasBuffEfect;
    
    public AbilityBehaviour abilityBehaviour;
}
