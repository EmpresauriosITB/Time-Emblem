using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DamageBehaviour")]
public class DamageBehaviour : AbilityBehaviour {

    public bool hasDebuff;
    public BuffAndDebuff buff;
    public bool isRangeAttack;

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {
        
        int attack;
        if (isPhysical) attack = actor.GetComponent<CharacterUnitController>().currentPhysicalPower;
        else attack = actor.GetComponent<CharacterUnitController>().currentMentalPower;
        int deffense;
        Debug.Log(actor.name);
        if (actor.gameObject.GetComponent<CharacterUnitController>().isHumanoid) {
            if (isRangeAttack) { actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("RangeAttack1Trigger"); }
            else { actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("PunchTrigger"); }
        } else {
            if (isRangeAttack) { actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("breatheFire"); }
            else { actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("flyAttack"); }
        }
        Debug.Log(targets.Count);
        for (int i = 0; i < targets.Count; i++) {
            if (hasDebuff) {
                if (Random.Range(0, 100) < buff.activationPorcentage)
                {
                    buff.Init(targets[i].GetComponent<CharacterUnitController>());
                    targets[i].GetComponent<CharacterUnitController>().buffAndDebuffs.Add(buff);
                }
            }
            if (isPhysical) deffense = targets[i].GetComponent<CharacterUnitController>().currentPhysicalDefense;
            else deffense = targets[i].GetComponent<CharacterUnitController>().currentMentalDefense;
            targets[i].GetComponent<CharacterUnitController>().currentHp -= DamageCalculator.CalculateDamage(Power, attack, deffense, false);
            if (targets[i].gameObject.GetComponent<CharacterUnitController>().isHumanoid) {
                Debug.Log(targets[i].gameObject.name);
                targets[i].gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("LightHitTrigger"); }
            else { targets[i].gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("gotHit1"); }
            
        }

        return targets.Count > 0;
    }
}
