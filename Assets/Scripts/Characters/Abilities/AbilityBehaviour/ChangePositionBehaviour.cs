using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionBehaviour : AbilityBehaviour
{

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {
        if (targets.Count > 0) {
            GameObject go = targets[0].gameObject;
            Unit ut = go.GetComponent<Unit>();
            Unit ua = actor.GetComponent<Unit>();

            Transform taux = go.transform;
            go.transform.position = actor.transform.position;
            actor.transform.position = taux.position;


            int xaux = ut.tileX, yaux = ut.tileY;
            ut.tileX = ua.tileX;
            ut.tileY = ua.tileY;

            ua.tileX = xaux;
            ua.tileY = yaux;
        }

        return targets.Count > 0;
    }
}
