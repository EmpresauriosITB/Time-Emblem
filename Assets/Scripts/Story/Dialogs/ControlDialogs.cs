using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDialogs : MonoBehaviour
{
    public Animation anim;
    public Queue <string> queueDialogs;
    Texts texts;
    [SerializeField] TextMeshProUGUI screenText;

    private void Start()
    {
        anim = GetComponent<Animation>();
        queueDialogs = new Queue<string>();
    }

    public void ActivatePoster(Texts textObject)
    {
        anim.Play("BordeDialogo");
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

    public void ClosePoster()
    {
        anim.Play("BordeDialogoClose");
    }
}
