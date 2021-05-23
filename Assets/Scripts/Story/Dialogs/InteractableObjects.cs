using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public Texts texts;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("DENTRO");  
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E PULSADA");
                FindObjectOfType<ControlDialogs>().ActivatePoster(texts);
            }
        }
    }
}
