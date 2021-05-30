using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverPathText : MonoBehaviour
{
    public GameObject textIntro;
    Animation textAnim;

    void Start()
    {
        textIntro = GameObject.Find("TextIntro (4)");
        textAnim = textIntro.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("IntroRiverText");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("ExitRiverText");
        }
    }
}
