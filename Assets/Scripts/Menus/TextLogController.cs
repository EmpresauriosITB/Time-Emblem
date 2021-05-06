using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogController : MonoBehaviour
{
    [SerializeField] private GameObject text;

    private List<GameObject> textItems;

    private void onEnable()
    {
    }

    public void LogText(string newTextString)
    {
        
        textItems = new List<GameObject>();
        
        GameObject newText = Instantiate(text) as GameObject;
        newText.SetActive(true);

        newText.GetComponent<TextLogItem>().SetText(newTextString);
        newText.transform.SetParent(text.transform.parent, false);

        Debug.Log(newText);
        Debug.Log(textItems);

        textItems.Add(newText.gameObject);

    }

    public void DeleteTextItems()
    {
       
        for (int i = 0; i < textItems.Count; i++)
        {
            Destroy(gameObject);
        }
    }
}
