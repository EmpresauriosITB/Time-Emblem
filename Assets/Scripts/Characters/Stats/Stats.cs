using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Character Stats")]
public class Stats : ScriptableObject
{
    public float hp;
    public float physicalPower;
    public float physicalDefense;
    public float mentalPower;
    public float mentalDefense;
    public float velocity;
    public float forceValue;
    public float gridSpeed;
    public float numActions;
}
