using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextIntro : MonoBehaviour
{
    public Camera pixelCamera;
    public GameObject textIntro;
    Animation textAnim;

    void Start()
    {
        pixelCamera = GameObject.FindObjectOfType<Camera>();
        textIntro = GameObject.Find("TextIntro");
        textAnim = textIntro.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pixelCamera.fieldOfView = 30f;
            textAnim.Play("TextPanel");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pixelCamera.fieldOfView = 15f;
            textAnim.Play("ExitZone");
        }
    }
}
