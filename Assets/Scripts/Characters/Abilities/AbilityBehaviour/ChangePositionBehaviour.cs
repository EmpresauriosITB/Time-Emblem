using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChangePositionBehaviour")]
public class ChangePositionBehaviour : AbilityBehaviour
{

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor, bool isRangeAttack) {
        if (targets.Count > 0) {
            actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("SpecialAttack1Trigger");
            GameObject go = targets[0].gameObject;
            Unit ut = go.GetComponent<Unit>();
            Unit ua = actor.GetComponent<Unit>();
            PathFind.setAllowedToCLickTiles(actor.GetComponent<CharacterUnitController>().currentGridSpeed, ua.tileX, ua.tileY, false, InstanceAbilityData.map, TileState.nothing, null);

            int xaux = ut.tileX, yaux = ut.tileY;
            ut.tileX = ua.tileX;
            ut.tileY = ua.tileY;

            ua.tileX = xaux;
            ua.tileY = yaux;

            go.transform.position = new Vector3(ut.tileX, go.transform.position.y, ut.tileY);
            actor.transform.position = new Vector3(ua.tileX, actor.transform.position.y, ua.tileY);

            Debug.Log("Actor: " + ua.tileX + " " + ua.tileY);
            Debug.Log("Target: " + ut.tileX + " " + ut.tileY);

            

            Debug.Log("Actor: " + ua.tileX + " " + ua.tileY);
            Debug.Log("Target: " + ut.tileX + " " + ut.tileY);

            
        }

        return targets.Count > 0;
    }
}
