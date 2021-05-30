using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCarta : MonoBehaviour
{
    public GameObject character;
    public Text text;

    private void Start() {
        text.text = "" + character.GetComponent<CharacterUnitController>().character.stats.forceValue;
    }
}
    