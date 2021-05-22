using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDialogs : MonoBehaviour
{
    private Animator anim;
    private Queue <string> queueDialogs;
    Texts texts;
    [SerializeField] TextMeshProUGUI screenText;

    public void ActivatePoster(Texts textObject)
    {
        anim.SetBool("BordeDialogo", true);
        texts = textObject;
    }

    public void ActivateText()
    {
        queueDialogs.Clear();
        foreach (string textSave in texts.arrayTexts)
        {
            queueDialogs.Enqueue(textSave);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        if(queueDialogs.Count == 0)
        {
            ClosePoster();
            return;
        }

        string currentSentence = queueDialogs.Dequeue();
        screenText.text = currentSentence;
    }

    void ClosePoster()
    {
        anim.SetBool("BordeDialogo", false);
    }

}
