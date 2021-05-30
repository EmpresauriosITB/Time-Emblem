using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTempleText : MonoBehaviour
{
    public GameObject textIntro;
    Animation textAnim;

    void Start()
    {
        textIntro = GameObject.Find("TextIntro (3)");
        textAnim = textIntro.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("IntroGreenTemple");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("ExitGreenTemple");
        }
    }
}
