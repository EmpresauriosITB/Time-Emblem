using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassInformationTOBattleManager : MonoBehaviour {

    public BattleManager battleManager;
    public GameObject board;

    public void PassPlayerTeam() {
        if (board.transform.childCount > 0) {
            List<GameObject> cards = new List<GameObject>();
            for (int i = 0; i < board.transform.childCount; i++) {
                cards.Add(board.transform.GetChild(i).gameObject.GetComponent<DataCarta>().character);
            }
            battleManager.pt = cards;
            battleManager.allowToGoNextState();
        }
    }
}
