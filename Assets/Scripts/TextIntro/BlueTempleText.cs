using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTempleText : MonoBehaviour
{
    public GameObject textIntro;
    Animation textAnim;

    void Start()
    {
        textIntro = GameObject.Find("TextIntro (2)");
        textAnim = textIntro.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("IntroBlueTemple");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            textAnim.Play("ExitBlueTemple");
        }
    }
}
