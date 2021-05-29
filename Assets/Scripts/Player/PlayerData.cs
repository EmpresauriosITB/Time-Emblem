using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
    public int forceValue;
    public List<GameObject> team; 

    public void Init() {
        PlayerData pd = BinariSave.LoadPlayerData();
        forceValue = pd.forceValue;
        team = pd.team;
    }

}
