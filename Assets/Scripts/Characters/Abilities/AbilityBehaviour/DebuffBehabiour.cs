using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "DebuffBehabiour")]
public class DebuffBehabiour : AbilityBehaviour {

    public BuffAndDebuff buff;

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {
        CharacterUnitController unitCh = actor.gameObject.GetComponent<CharacterUnitController>();
        for (int i = 0; i < targets.Count; i++) {
            CharacterUnitController target = targets[i].GetComponent<CharacterUnitController>();
            buff.Init(target);
            target.buffAndDebuffs.Add(buff);
            unitCh.animator.SetTrigger("SpecialAttack1Trigger");
        }

        return targets.Count > 0;
    }
}
