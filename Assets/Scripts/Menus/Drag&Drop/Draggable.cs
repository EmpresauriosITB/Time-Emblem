using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    public Transform parentToReturnTo = null;
    private Transform antiqueParent = null;
    private DropZone d;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        antiqueParent = this.transform.parent;
        d =  parentToReturnTo.GetComponent<DropZone>();
        d.alreadyAdded = false;
        if (d.hasLimit) {
            d.updateTotalTeamNum((int) this.GetComponent<DataCarta>().character.GetComponent<CharacterUnitController>().character.stats.forceValue, false);
        }
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        if (!parentToReturnTo.GetComponent<DropZone>().alreadyAdded && parentToReturnTo.GetComponent<DropZone>().hasLimit) {
            Debug.Log("Suma");
            d.updateTotalTeamNum((int)  this.GetComponent<DataCarta>().character.GetComponent<CharacterUnitController>().character.stats.forceValue, true);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

        
}
