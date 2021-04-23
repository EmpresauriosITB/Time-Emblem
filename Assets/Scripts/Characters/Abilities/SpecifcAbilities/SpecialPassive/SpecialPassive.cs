using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialPassive : Abilities {

    private string conditionsToUnlock;

    public abstract bool checkConditionsToUnlock();

    public void SetConditionsToUnlock(string conditionsToUnlock) { this.conditionsToUnlock = conditionsToUnlock; }
    public string GetConditionsToUnlock() { return conditionsToUnlock; }
}

