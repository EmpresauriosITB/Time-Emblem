using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "DebuffBehabiour")]
public class DebuffBehabiour : AbilityBehaviour {

    public BuffAndDebuff buff;

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {
        for (int i = 0; i < targets.Count; i++) {
            buff.Init(targets[i].GetComponent<CharacterUnitController>());
            targets[i].GetComponent<CharacterUnitController>().buffAndDebuffs.Add(buff);
            actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("SpecialAttack1Trigger");
        }

        return targets.Count > 0;
    }
}
