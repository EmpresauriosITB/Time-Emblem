using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBehaviour : ScriptableObject {
    public abstract bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor);
}
