using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    public bool hasLimit;
    private int limitNum;
    public int totalTeamNum = 0;
    public GameObject textMax, textCurrent;

    public bool alreadyAdded;
    public void OnDrop(PointerEventData eventData) {


        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Character character = eventData.pointerDrag.GetComponent<DataCarta>().character.GetComponent<CharacterController>().character;
        if (hasLimit) {
            if (limitNum + 1 >= totalTeamNum + character.stats.forceValue) {
                if (d != null) {
                    updateTotalTeamNum((int) (character.stats.forceValue), true);
                    alreadyAdded = true;
                    d.parentToReturnTo = this.transform;
                }
            }
        }
        else {
            if (d != null) {
                d.parentToReturnTo = this.transform;
            }
        }
    }

    public void updateTotalTeamNum(int num, bool plus) {
        if (plus)  totalTeamNum += num;
        else totalTeamNum -= num;
        textCurrent.GetComponent<Text>().text = "" + totalTeamNum;
    }

    public void updateLimitNum(int num) {
        limitNum = num;
        textMax.GetComponent<Text>().text = "" + limitNum;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}