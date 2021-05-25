using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public Texts texts;
    //ControlDialogs control;

    //private void Start()
    //{
        //control = GetComponent<ControlDialogs>();
    //}


    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Personaje quieto 
                //collider.gameObject.GetComponent<PlayerController>().speed = 0f;
                FindObjectOfType<ControlDialogs>().ActivatePoster(texts);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.transform.GetChild(2).gameObject;
        obj.SetActive(false);
        FindObjectOfType<ControlDialogs>().ClosePoster();
    }
}
