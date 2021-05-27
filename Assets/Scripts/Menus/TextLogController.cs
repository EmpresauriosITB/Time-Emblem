using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogController : MonoBehaviour
{
    public Button button;

    private List<GameObject> textItems;

    public delegate void DestroyText();
    public event DestroyText destroyText;
   
    private void Update() {

    }

    public void LogText(Abilities a, GameObject g)
    {
        
        textItems = new List<GameObject>();

        Button newText = Instantiate(button) as Button;
        newText.gameObject.SetActive(true);

        newText.GetComponentInChildren<TextLogItem>().SetText(a.AbilityName);
        newText.GetComponent<ButtonFunction>().subscribeEvent(this, a, g);
        newText.transform.SetParent(this.transform.GetChild(0).transform.GetChild(0).transform, false);

        textItems.Add(newText.gameObject);

    }

    public void DeleteTextItems() {
        Debug.Log(destroyText != null);
        destroyText();
    }

    public bool DestroyTextHasSucribedEvents() {
        return destroyText != null;
    }
}
