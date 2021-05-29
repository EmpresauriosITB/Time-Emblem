using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTempleText : MonoBehaviour
{
    public GameObject textIntro;
    Animation textAnim;

    void Start()
    {
        textIntro = GameObject.Find("TextIntro (1)");
        textAnim = textIntro.GetComponent<Animation>();   
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("IntroRedTemple");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("ExitRedTemple");
        }
    }
}
