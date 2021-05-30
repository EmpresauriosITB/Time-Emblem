using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawningBehabiour")]
public class SpawningBehabiour : AbilityBehaviour {

    public GameObject spawn;

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor, bool isRangeAttack) {
        GameObject target = targets[0];
        actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("SpecialAttack1Trigger");
        int x = 0, y = 0;
        bool flag = true;
        Unit u = target.GetComponent<Unit>();
        Node n = InstanceAbilityData.map.abilityGraph[u.tileX, u.tileY];
        
        for (int i = 0; i < n.neighbours.Count && flag; i++) {
            Node currentN = n.neighbours[i];

            if (InstanceAbilityData.map.currentTiles[n.x, n.y] != 0) {
                x = n.x;
                y = n.y;
            }
        }

        Vector3 v = new Vector3(x, spawn.transform.position.y, y);
        spawn.transform.position = v;
       
        GameObject goInit = GameObject.Instantiate(spawn);
        goInit.transform.parent = actor.transform.parent;
        return targets.Count > 0;
    }
}
