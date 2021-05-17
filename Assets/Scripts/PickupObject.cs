using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Camera pixelCamera;

    public void Start()
    {
        pixelCamera = GameObject.FindObjectOfType<Camera>();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject child = this.gameObject.transform.GetChild(0).gameObject;
                child.SetActive(true);
                this.gameObject.GetComponent<PlayerController>().camara = collider.gameObject.GetComponent<PlayerController>().camara;
                gameObject.GetComponent<PlayerController>().camara.transform.GetChild(0).GetComponent<PlayerFollow>().PlayerTransform = gameObject.transform;
                gameObject.GetComponent<PlayerController>().setCanMove(true);
                collider.gameObject.SetActive(false);
                pixelCamera.fieldOfView = 60f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject obj = other.transform.GetChild(2).gameObject;
            obj.SetActive(false);
        }
    }
}
