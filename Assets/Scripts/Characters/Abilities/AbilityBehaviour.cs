﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBehaviour : MonoBehaviour {
    public abstract void doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor);
}
