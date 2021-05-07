using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogItem : MonoBehaviour
{
    private TextLogController tlg;

    public void SetText (string myText)
    {
        GetComponent<Text>().text = myText;
    }

    public void subscribeEvent(TextLogController evento) {
        tlg = evento;
        evento.destroyText += DestroyText;
    }

    public void DestroyText() {
        Debug.Log("AAAA");
        tlg.destroyText -= DestroyText;
        Destroy(this.gameObject);
    }
}
