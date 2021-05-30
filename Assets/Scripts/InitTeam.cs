using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTeam : MonoBehaviour {

    public PlayerData player;
    public CardSet cardSet;

    void Start() {
        cardSet.cards = new List<GameObject>();
        for (int i = 0; i < player.team.Count; i++) {
            cardSet.cards.Add(player.team[i]);
        }
        cardSet.forceValue = player.forceValue;
        
    }
}
