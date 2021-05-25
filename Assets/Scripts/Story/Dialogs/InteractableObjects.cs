using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public Texts texts;
    bool talking = false;



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
                if(this.gameObject.name.Equals("Sensei_Red_Temple")){
                    GameObject.Find("Partner").SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.transform.GetChild(2).gameObject;
        obj.SetActive(false);
        if(talking == true) {
            talking = false;
            this.gameObject.GetComponent<StoryIAMovement>().Reload();
            FindObjectOfType<ControlDialogs>().ClosePoster();
        }
    }
}
