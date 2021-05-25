using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public Texts texts;
    bool talking = false;
    public GameObject Sensei;

    private void Start()
    {
        Sensei = GameObject.Find("Sensei_Red_Temple");
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                talking = true;
                this.gameObject.GetComponent<StoryIAMovement>().Stop();
                FindObjectOfType<ControlDialogs>().ActivatePoster(texts);
                //ERROR
                //if(this.gameObject.name.Equals(Sensei)){
                    //FindObjectOfType<ActivateObject>().activateObject();
                //}
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.transform.GetChild(2).gameObject;
        obj.SetActive(false);
        if (talking == true)
        {
            if (this.gameObject.name.Equals(Sensei))
            {
                FindObjectOfType<ActivateObject>().activateObject();
            }
            else
            {
                talking = false;
                this.gameObject.GetComponent<StoryIAMovement>().Reload();
                FindObjectOfType<ControlDialogs>().ClosePoster();
            }
        }
    }
}
