using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawningBehabiour")]
public class SpawningBehabiour : AbilityBehaviour {

    public GameObject spawn;

    public override bool doAbility(int Power, bool isPhysical, List<GameObject> targets, GameObject actor) {
        GameObject target = targets[0];
        actor.gameObject.GetComponent<CharacterUnitController>().animator.SetTrigger("SpecialAttack1Trigger");
        int x = 0, y = 0;
        bool flag = true;
        Unit u = target.GetComponent<Unit>();
        Node n = InstanceAbilityData.map.abilityGraph[u.tileX, u.tileY];
        for (int i = 0; i < n.neighbours.Count && flag; i++) {
            Node currentN = n.neighbours[i];
            if (InstanceAbilityData.map.currentTiles[n.x, n.y] != 0) {
                flag = false;
                x = n.x;
                y = n.y;
            }
        }
        Vector3 v = new Vector3(x, spawn.transform.position.y, y);
        Transform t = spawn.transform;
        t.position = v;
        spawn.GetComponent<CharacterUnitController>().InitBattleManager(actor.AddComponent<CharacterUnitController>().bm, null);
        GameObject goInit = GameObject.Instantiate(spawn, t);
        goInit.transform.parent = actor.transform.parent;
        return targets.Count > 0;
    }
}
