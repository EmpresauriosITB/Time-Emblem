using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBehaviour : AbilityBehaviour {

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {

        for (int i = 0; i < targets.Count; i ++) {
            CharacterController cc = targets[i].gameObject.GetComponent<CharacterController>();
            cc.character.currentHp += DamageCalculator.CalculateHeal(Power, cc.character.currentMentalPower);
            if (cc.character.currentHp > cc.character.stats.hp) cc.character.currentHp = (int) cc.character.stats.hp;
        }

        return targets.Count > 0;
    }
}