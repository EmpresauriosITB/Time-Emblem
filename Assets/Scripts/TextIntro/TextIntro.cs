using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextIntro : MonoBehaviour
{
    public Camera pixelCamera;
    public GameObject textIntro;
    Animation textAnim;
    public RenderTexture renderTexture;
    public RawImage raw;

    void Start()
    {
        pixelCamera = FindObjectOfType<Camera>();
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
