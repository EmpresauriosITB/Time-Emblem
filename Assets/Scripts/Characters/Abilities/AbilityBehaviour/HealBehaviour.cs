using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HealBehaviour")]
public class HealBehaviour : AbilityBehaviour {

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {

        for (int i = 0; i < targets.Count; i ++) {
            CharacterUnitController cc = targets[i].gameObject.GetComponent<CharacterUnitController>();
            cc.currentHp += DamageCalculator.CalculateHeal(Power, cc.currentMentalPower);
            if (cc.currentHp > cc.character.stats.hp) cc.currentHp = (int) cc.character.stats.hp;
        }

        return targets.Count > 0;
    }
}