using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogController : MonoBehaviour
{
    public GameObject text;

    private List<GameObject> textItems;

    public delegate void DestroyText();
    public event DestroyText destroyText;

    private void onEnable() {
    }

    public void LogText(string newTextString)
    {
        
        textItems = new List<GameObject>();
        
        GameObject newText = Instantiate(text) as GameObject;
        newText.SetActive(true);

        newText.GetComponent<TextLogItem>().SetText(newTextString);
        newText.GetComponent<TextLogItem>().subscribeEvent(this);
        newText.transform.SetParent(this.transform.GetChild(0).transform.GetChild(0).transform, false);

        Debug.Log(newText);
        Debug.Log(textItems);

        textItems.Add(newText.gameObject);

    }

    public void DeleteTextItems() {
        destroyText();
    }
}
