using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DamageBehaviour")]
public class DamageBehaviour : AbilityBehaviour {

    public bool hasDebuff;
    public BuffAndDebuff buff;
    

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor, bool isRangeAttack) {
        CharacterUnitController actorCh = actor.GetComponent<CharacterUnitController>();
        int attack;
        if (isPhysical) attack = actorCh.currentPhysicalPower;
        else attack = actorCh.currentMentalPower;
        int deffense;
        if (actorCh.isHumanoid) {
            if (isRangeAttack) { actorCh.animator.SetTrigger("RangeAttack1Trigger"); }
            else { actorCh.animator.SetTrigger("PunchTrigger"); }
        } else {
            if (isRangeAttack) { actorCh.animator.SetTrigger("breatheFire"); }
            else { actorCh.animator.SetTrigger("flyAttack"); }
        }
        for (int i = 0; i < targets.Count; i++) {
            CharacterUnitController targetCh = targets[i].GetComponent<CharacterUnitController>();
            if (hasDebuff) {
                if (Random.Range(0, 100) < buff.activationPorcentage)
                {
                    buff.Init(targetCh);
                    targetCh.buffAndDebuffs.Add(buff);
                }
            }
            if (isPhysical) deffense = targetCh.currentPhysicalDefense;
            else deffense = targetCh.currentMentalDefense;
            targetCh.currentHp -= DamageCalculator.CalculateDamage(Power, attack, deffense, false);
            if (targetCh.isHumanoid) { targetCh.animator.SetTrigger("LightHitTrigger"); }
            else { targetCh.animator.SetTrigger("gotHit1"); }
            
        }

        return targets.Count > 0;
    }
}
