using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDialogs : MonoBehaviour
{
    public Animation anim;
    public Queue <string> queueDialogs;
    Texts texts;
    public bool talking;
    [SerializeField] TextMeshProUGUI screenText;

    private void Start()
    {
        anim = GetComponent<Animation>();
        queueDialogs = new Queue<string>();
        talking = false;
    }

    private void Update()
    {
        NextText();
    }


    public void ActivatePoster(Texts textObject)
    {
        anim.Play("BordeDialogo");
        talking = true;
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
            talking = false;
            return;
        }

        string currentSentence = queueDialogs.Dequeue();
        screenText.text = currentSentence;
    }

    public void NextText()
    {
        if (talking == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }
    }

    public void ClosePoster()
    {
        anim.Play("BordeDialogoClose");
    }
}
