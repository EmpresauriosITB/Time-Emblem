using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardSet")]
public class CardSet : ScriptableObject {
    public List<GameObject> cards;
    public int forceValue;
}
