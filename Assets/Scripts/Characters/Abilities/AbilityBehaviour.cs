using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBehaviour : MonoBehaviour {
    public abstract void doAbility(int Power, List<GameObject> targets);
}
