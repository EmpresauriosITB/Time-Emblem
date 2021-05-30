using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCloneInit : MonoBehaviour {
    void Start() {
        CharacterUnitController ch = this.gameObject.GetComponent<CharacterUnitController>();
        BattleManager bm = this.gameObject.transform.parent.transform.parent.transform.parent.GetChild(2).GetComponent<BattleManager>();
        ch.InitBattleManager(bm, bm.tileMap);
    }
}
