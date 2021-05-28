using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DamageBehaviour")]
public class DamageBehaviour : AbilityBehaviour {

    public bool hasDebuff;
    public BuffAndDebuff buff;

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {
        
        int attack;
        if (isPhysical) attack = actor.GetComponent<CharacterUnitController>().character.currentPhysicalPower;
        else attack = actor.GetComponent<CharacterUnitController>().character.currentMentalPower;
        int deffense;
        for (int i = 0; i < targets.Count; i++) {
            if (Random.Range(0, 100) < buff.activationPorcentage) {

            }
            if (isPhysical) deffense = targets[i].GetComponent<CharacterUnitController>().character.currentPhysicalDefense;
            else deffense = targets[i].GetComponent<CharacterUnitController>().character.currentMentalDefense;
            targets[i].GetComponent<CharacterUnitController>().character.currentHp -= DamageCalculator.CalculateDamage(Power, attack, deffense, false);
        }

        return targets.Count > 0;
    }
}
