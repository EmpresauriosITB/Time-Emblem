using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects2 : MonoBehaviour
{
    public Texts texts;
    bool talking = false;
    public GameObject dragon;

    private void Start()
    {
        dragon = GameObject.Find("DragonEnemie");
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (this.Equals(dragon))
                {
                    waitBattleDragon();
                }
                talking = true;
                this.gameObject.GetComponent<StoryIAMovement>().Stop();
                FindObjectOfType<ControlDialogs>().ActivatePoster(texts);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.transform.GetChild(2).gameObject;
        obj.SetActive(false);
        if (talking == true)
        {
            if (this.gameObject.Equals(dragon))
            {
                EventBattle();
            }

            talking = false;
            this.gameObject.GetComponent<StoryIAMovement>().Reload();
            FindObjectOfType<ControlDialogs>().ClosePoster();
        }
    }

    public void EventBattle()
    {
        Debug.Log("EMPIEZA BATALLA");
    }

    IEnumerator waitBattleDragon()
    {
        yield return new WaitForSeconds(2);
        EventBattle();
        dragon.SetActive(false);
    }
}
