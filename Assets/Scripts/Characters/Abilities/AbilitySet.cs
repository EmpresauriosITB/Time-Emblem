using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySet")]
public class AbilitySet : ScriptableObject
{
    public List<AbilityCommon.AbiltiesId> abilities;
}
