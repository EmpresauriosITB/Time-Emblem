using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    public bool hasLimit;
    public int limitNum;
    public int totalTeamNum = 0;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "was dropped on" + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Character character = eventData.pointerDrag.GetComponent<DataCarta>().character;
        if (hasLimit) {
            if (limitNum > totalTeamNum + character.stats.forceValue) {
                if (d != null) {
                    totalTeamNum += (int) character.stats.forceValue;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }
}
