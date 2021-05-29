using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassInformationTOBattleManager : MonoBehaviour {

    public BattleManager battleManager;
    public GameObject board;

    public void PassPlayerTeam() {
        Debug.Log(board.transform.childCount);
        Debug.Log(board.name);
        Debug.Log(this.transform.GetChild(1).transform.childCount);
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
