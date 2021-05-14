using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    private TextLogController tlg;
    private Abilities abilities;

 
    public void subscribeEvent(TextLogController evento, Abilities a)
    {
        abilities = a;
        tlg = evento;
        evento.destroyText += DestroyText;
    }

    public void DestroyText()
    {
        Debug.Log("AAAA");
        tlg.destroyText -= DestroyText;
        Destroy(this.gameObject);
    }

    public void buttonClicked()
    {
        Debug.Log(abilities.GetName());
    }
}
